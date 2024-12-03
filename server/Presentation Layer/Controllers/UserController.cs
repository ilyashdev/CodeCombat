using CodeCombat.Application_Layer.Services.IService;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CodeCombat.Presentation_Layer.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUser(long id)
    {
        var user = await _userService.GetUserAsync(id);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpRequest request)
    {
        await _userService.SignUpAsync(request);
        return Ok();
    }
}