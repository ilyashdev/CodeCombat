using CodeCombat.Contracts;
using CodeCombat.DataAccess.Entity;
using CodeCombat.DataAccess.Repositories;
using CodeCombat.Models;
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
    public async Task<bool> SolutionUpload(TInitRequest user,SolutionRequest solution)
    {
        var inputFile = File.ReadAllLines(_webHostEnvironment.WebRootPath+"/input.txt");
        var outputFile = File.ReadAllLines(_webHostEnvironment.WebRootPath+"/output.txt");
        int i=0;
        double allRuntime = 0;
        var solutions = new SolutionsEntity();
        solutions.Code = solution.code;
        foreach (var contestValue in inputFile.Zip(outputFile, Tuple.Create))
        {
            var time = TimeOnly.FromDateTime(DateTime.UtcNow);
            var response = await SolutionProccesing(solution, contestValue.Item1);
            var runtime = TimeOnly.FromDateTime(DateTime.UtcNow)- time;
            dynamic parsResponse = JObject.Parse(response);
            if(parsResponse.output != contestValue.Item2 + "\n")
            {
                solutions.Runtime = -1;
                solutions.Status = "wrong answer";
                return await _userRepository.AddSolution(user, solutions);
            }
            else if (parsResponse.error != "")
            {
                solutions.Runtime = -1;
                solutions.Status = parsResponse.error;
                return await _userRepository.AddSolution(user, solutions);
            }
            allRuntime += runtime.TotalSeconds;
            i++;
        }
        solutions.Status = "Accept";
        solutions.Runtime = allRuntime/i;
        return await _userRepository.AddSolution(user,solutions);
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

    public async Task<List<SolutionsEntity>> GetSolution(TInitRequest request)
    {
        return await _userRepository.GetSolution(request);
    }
    public async Task<List<SolutionsEntity>> GetFiltredTop()
    {
        return (await _userRepository.GetTopList()).Where(s => s.Runtime > 0).OrderBy(s => s.Runtime).ToList();
    }
}