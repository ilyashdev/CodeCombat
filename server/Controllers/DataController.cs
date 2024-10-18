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
        [Route("Coin")]
        [HttpGet]
        public async Task<IActionResult> GetTokenValue([FromQuery]TInitRequest request)
        {
            var value = await _dataService.GetTokenValue(request);
            if (value != null)
            return Ok(value);
            else
            return BadRequest("invalid user");
        }
        [Route("Solutions")]
        [HttpPost]
        public async Task<IActionResult> PostSolution([FromQuery]TInitRequest request, [FromBody]SolutionRequest solrequest)
        {
            await _dataService.SolutionUpload(request, solrequest);
            return Ok();
        }
        [Route("Solutions")]
        [HttpGet]
        public async Task<IActionResult> PostSolution([FromQuery]TInitRequest request)
        {
            var response = await _dataService.GetSolution(request);
            if(response == null)return BadRequest("no solutions");
            return Ok(response);
        }

        [Route("Top")]
        [HttpGet]
        public async Task<IActionResult> GetTop()
        {
            return Ok(await _dataService.GetFiltredTop());
        }

    }
