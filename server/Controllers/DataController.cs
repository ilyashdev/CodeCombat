using Microsoft.AspNetCore.Mvc;
using CodeCombat.Services;
using CodeCombat.Contracts;

namespace CodeCombat.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly DataService _dataService;
        public DataController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTokenValue([FromQuery]TInitRequest request)
        {
            var value = await _dataService.GetTokenValue(request);
            if (value != null)
            return Ok(value);
            else
            return BadRequest("invalid user");
        }
        [HttpPost]
        public async Task<IActionResult> PostSolution([FromQuery]TInitRequest request, [FromBody]SolutionRequest solrequest)
        {
            return Ok(await _dataService.SolutionProccesing(solrequest, "12"));
        }
    }
