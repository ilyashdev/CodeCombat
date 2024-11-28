using CodeCombat.Application_Layer.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace CodeCombat.Presentation_Layer.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourseList(int page)
    {
        var list = await _courseService.GetCourseListAsync(page);
        return Ok(list);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCourse(Guid id)
    {
        var course = await _courseService.GetCourseAsync(id);
        return Ok();
    }

    [HttpGet]
    [Route("{courseId}/{module}")]
    public async Task<IActionResult> GetCourse(Guid courseId, int module)
    {
        var courseModule = await _courseService.GetModuleAsync(courseId, module);
        return Ok(courseModule);
    }

    [HttpPost]
    public async Task<IActionResult> PostCourse()
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> EditCourse(Guid id)
    {
        return Ok();
    }
}