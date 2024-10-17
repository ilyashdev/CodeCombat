using CodeCombat.Contracts;
using CodeCombat.DataAccess.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

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

    public async Task<string> SolutionProccesing(SolutionRequest solution,string input)
    {
        var jsonBody = new StringContent("{\"code\":\""+solution.code+"\",\"language\":\""+solution.langType+"\",\"input:\""+input+"}");
        var responce = await _httpClient.PostAsync(_uri+"?code=print(\"hello\")&language=py&input=10",jsonBody);
        return await responce.Content.ReadAsStringAsync();
    }

}