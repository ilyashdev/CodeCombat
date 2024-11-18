using CodeCombat.Contracts;
using CodeCombat.DataAccess.Entity;
using CodeCombat.DataAccess.Repositories;
using CodeCombat.Models;
using Newtonsoft.Json.Linq;

namespace CodeCombat.Services;

public class DataService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly HttpClient _httpClient;
    private readonly UserRepository _userRepository;
    private readonly SolutionsRepository _solutionRepository;
    private readonly DailyRepository _dailyRepository;
    private readonly string _uri = "https://api.codex.jaagrav.in";
    public DataService(IWebHostEnvironment webHostEnvironment, 
                       UserRepository userRepository,
                       SolutionsRepository solutionsRepository,
                       DailyRepository dailyRepository)
    {
        _webHostEnvironment = webHostEnvironment;
        _solutionRepository = solutionsRepository;
        _dailyRepository = dailyRepository;
        _userRepository = userRepository;
        _httpClient = new HttpClient();
    }
    
    public async Task<double?> GetTokenValue(User userData)
    {
        var user = await _userRepository.FindUserAsync(userData);
        if(user != null)
        return user.CoinValue;
        else
        return null;
    }
    public async Task<bool> SolutionUpload(User user,SolutionRequest solution)
    {
        var daily = await _dailyRepository.GetDaily();
        if(daily == null)
        throw new Exception("no data today");

        int i=0;
        double allRuntime = 0;
        var solutions = new SolutionsEntity();
        solutions.Code = solution.code;
        solutions.LangType = solution.langType;
        foreach (var test in daily.Test)
        {
            var time = TimeOnly.FromDateTime(DateTime.UtcNow);
            var response = await SolutionProccesing(solution, test.input);
            var runtime = TimeOnly.FromDateTime(DateTime.UtcNow) - time;
            dynamic parsResponse = JObject.Parse(response);
            if (parsResponse.error != "")
            {
                solutions.Runtime = -1;
                solutions.Status = parsResponse.error;
            }
            else 
            if(parsResponse.output != test.output + "\n")
            {
                solutions.Runtime = -1;
                solutions.Status = "wrong answer";
            }
            allRuntime += runtime.TotalSeconds;
            i++;
        }
        solutions.Status = "Accept";
        solutions.Runtime = allRuntime/i;
        await _solutionRepository.AddSolution(solutions);
        return false;
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

    public async Task<List<SolutionsEntity>?> GetSolution(TInitRequest request)
    {
        return null;
    }
    public async Task<List<SolutionsEntity>?> GetFiltredTop()
    {
        return await _solutionRepository.GetTopList();
    }
}