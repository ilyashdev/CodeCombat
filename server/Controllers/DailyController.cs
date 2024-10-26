using Microsoft.AspNetCore.Mvc;
using CodeCombat.Contracts;
using CodeCombat.Services;
using Newtonsoft.Json.Linq;
using System.Text;
using CodeCombat.DataAccess.Entity;
namespace CodeCombat.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class DailyController : ControllerBase
    {
        private DailyService _dailyService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DailyController( IWebHostEnvironment webHostEnvironment,
                                DailyService dailyService)
        {
            _webHostEnvironment = webHostEnvironment;
            _dailyService = dailyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetDaily()
        {
            try{
                return Ok(await _dailyService.GetDaily());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("admin")]
        [HttpPost]
        public async Task<IActionResult> PostDaily([FromBody] DailyPostRequest daily)
        {
            try
            {
                await _dailyService.AddDaily(daily);   
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllDaily()
        {
            return Ok(await _dailyService.GetAllDaily());
        }

    }
