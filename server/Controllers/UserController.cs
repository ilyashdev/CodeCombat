using Microsoft.AspNetCore.Mvc;
using CodeCombat.Contracts;
using CodeCombat.Services;
namespace CodeCombat.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserService _userService;
        public UserController(IWebHostEnvironment webHostEnvironment, UserService userService)
        {
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> TInit([FromQuery] TInitRequest request)
        {
            if(await _userService.TInit(request))
            return Ok("create user");
            return Ok();
        }

    }
