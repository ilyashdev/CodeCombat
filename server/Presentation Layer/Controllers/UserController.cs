using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
namespace CodeCombat.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }
            [HttpGet]
            [Route("{id}")]
            public async Task<IActionResult> GetUser(long id)
            {
                return Ok();
            }
            [HttpGet]
            public async Task<IActionResult> GetProfile()
            {
                return Ok();
            }
            [Route("{id}")]
            [HttpPost]
            public async Task<IActionResult> GetUserProfile(long id)
            {
                return Ok();
            }
    }
