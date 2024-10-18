using CodeCombat.Contracts;
using CodeCombat.DataAccess.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;

namespace CodeCombat.Services;

public class DataService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly HttpClient _httpClient;
    private readonly UserRepository _userRepository;
    private readonly string _uri = "https://api.codex.jaagrav.in";
    public DataService(IWebHostEnvironment webHostEnvironment, UserRepository userRepository)
    {
        _webHostEnvironment = webHostEnvironment;
        
        _userRepository = userRepository;
        _httpClient = new HttpClient();
    }
    
    public async Task<double?> GetTokenValue(TInitRequest userData)
    {
        var user = await _userRepository.FindUserAsync(userData);
        return user.CoinValue;
    }
    public async Task<SolutionUnit> SolutionResoult(SolutionRequest solution)
    {
        var inputFile = File.ReadAllLines(_webHostEnvironment.WebRootPath+"/input.txt");
        var outputFile = File.ReadAllLines(_webHostEnvironment.WebRootPath+"/output.txt");
        int i=0;
        TimeSpan allRuntime = TimeSpan.Zero;
        while (inputFile[i] != null)
        {
            var time = TimeOnly.FromDateTime(DateTime.UtcNow);
            var response = await SolutionProccesing(solution, inputFile[i]);
            var runtime = time - TimeOnly.FromDateTime(DateTime.UtcNow);
            dynamic parsResponse = JObject.Parse(response);
            if(parsResponse.output != outputFile[i])
            {
                return new SolutionUnit(TimeOnly.FromDateTime(DateTime.UtcNow),solution.code, runtime:runtime,status:"wrong answer");
            }
            else if (parsResponse.error != "")
            {
                return new SolutionUnit(TimeOnly.FromDateTime(DateTime.UtcNow), solution.code, runtime:runtime,status:parsResponse.error);
            }
            allRuntime += runtime;
            i++;
        }
        return new SolutionUnit(TimeOnly.FromDateTime(DateTime.UtcNow), solution.code, runtime:allRuntime/i,status:"Ok");

    }

    public async Task<string> SolutionProccesing(SolutionRequest solution,string input)
    {
        var parameters = new Dictionary<string, string>
    {
        { "code", solution.code },
        { "language", solution.langType},
        { "input",  input}
    };

    var encodedContent = new FormUrlEncodedContent(parameters);

    var response = await _httpClient.PostAsync(_uri, encodedContent);

    return await response.Content.ReadAsStringAsync();
    }

}