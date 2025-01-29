using CodeCombat.Application_Layer;
using CodeCombat.Application_Layer.Service;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CodeCombat.Presentation_Layer.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IValidateService _validateService;

    public UserController(IUserService userService, IValidateService validateService)
    {
        _userService = userService;
        _validateService = validateService;
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
    public async Task<IActionResult> GetJWT(string initDataRaw)
    {
        var initData = InitData.Parse(initDataRaw);
        if(!_validateService.Validate(initData))
        {
            return Unauthorized("Non-valid InitDataRaw");
        }
        
        return Ok();
    }
}