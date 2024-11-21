using Microsoft.AspNetCore.Mvc;
using CodeCombat.Contracts;
using CodeCombat.Services;
using CodeCombat.DataAccess.Repositories;
using CodeCombat.DataAccess.Entity;
namespace CodeCombat.Controllers;
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private CourseService _courseService;
        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] CoursePostRequest request)
        {
            await _courseService.AddCourse(new Models.User(1,"1"),request);
            return Ok(request);
        }
        [HttpGet]
        public async Task<IActionResult> GetCourse([FromQuery]Guid courseId)
        {
            var course = await _courseService.GetCourse(courseId);
            return Ok(course);
        }
        [Route("info")]
        [HttpGet]
        public async Task<IActionResult> GetCourseList()
        {
            var courseList = await _courseService.GetCourseList();
            return Ok(courseList);
        }
    }
