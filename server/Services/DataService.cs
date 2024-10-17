using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeCombat.Services;

public class DataService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public DataService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _dataDirPath = _webHostEnvironment.WebRootPath;
    }
    
    private readonly string _dataDirPath;

}