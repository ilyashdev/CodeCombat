using Microsoft.AspNetCore.Mvc;

namespace CodeCombat.Presentation_Layer.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
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

    [HttpPost]
    public async Task<IActionResult> SignUp()
    {
        return Ok();
    }
}