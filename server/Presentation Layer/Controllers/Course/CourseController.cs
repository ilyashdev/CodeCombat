using CodeCombat.Application_Layer.Service;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.AspNetCore.Mvc;
    [ApiController]
    [Route("content/[controller]")]
    public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetContent(Guid id)
    {
       return Ok(await _courseService.GetAsync(id, 0));// 0 is debug
    }
    public int TelegramId = 0;
    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> Path(ContentRequest request)
    {
        await _courseService.EditAsync(TelegramId, request);
        return Ok();    
    }
    [HttpPost]
    public async Task<IActionResult> Post(ContentRequest request)
    {
        await _courseService.PostAsync(TelegramId,request);
        return Ok();
    }
}

