using CodeCombat.Application_Layer.Services.IService;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.AspNetCore.Mvc;
namespace CodeCombat.Controllers;
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    public int TelegramId = 0;

        [HttpGet]
        public async Task<IActionResult> GetCourseList([FromQuery]int page, [FromBody]CourseListRequest? request)
        {
            var courseList = await _courseService.GetCourseListAsync(page,request);
            return Ok(courseList);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            var course = await _courseService.GetCourseAsync(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(ContentRequest request)
        {
            await _courseService.PostCourseAsync(TelegramId,request);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            await _courseService.DeleteCourseAsync(TelegramId,id);
            return Ok();
        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> EditCourse(Guid id, ContentRequest request)
        {
            await _courseService.EditCourseAsync(TelegramId,request);
            return Ok();
        }
    }
