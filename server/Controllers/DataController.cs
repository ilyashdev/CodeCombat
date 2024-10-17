using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CodeCombat.Services;

namespace CodeCombat.Controllers;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly DataService _dataService;
        public DataController(ILogger<DataController> logger, DataService dataService)
        {
            _dataService = dataService;
            _logger = logger;
        }

    }
