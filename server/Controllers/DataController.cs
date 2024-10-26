using Microsoft.AspNetCore.Mvc;
using CodeCombat.Services;
using CodeCombat.Contracts;
using Newtonsoft.Json.Linq;

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
            var value = await _dataService.GetTokenValue(new Models.User(request));
            if (value != null)
            return Ok(value);
            else
            return BadRequest("invalid user");
        }
        [Route("Solutions")]
        [HttpPost]
        public async Task<IActionResult> PostSolution([FromQuery]TInitRequest request, [FromBody]SolutionRequest solrequest)
        {
            if(await _dataService.SolutionUpload(new Models.User(request), solrequest))
            return Ok();
            else
            return BadRequest("invalid user");
        }
        [Route("Solutions")]
        [HttpGet]
        public async Task<IActionResult> GetSolution([FromQuery]TInitRequest request)
        {
            var response = await _dataService.GetSolution(request);
            if(response == null)return NoContent();
            return Ok(response);
        }

        [Route("Top")]
        [HttpGet]
        public async Task<IActionResult> GetTop()
        {
            return Ok(await _dataService.GetFiltredTop());
        }

    }
