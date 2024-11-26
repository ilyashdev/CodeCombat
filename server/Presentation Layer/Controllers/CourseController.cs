using Microsoft.AspNetCore.Mvc;
namespace CodeCombat.Controllers;
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        public CourseController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetCourseList(int Page)
        {
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            return Ok();
        }
        [HttpGet]
        [Route("{id}/{module}")]
        public async Task<IActionResult> GetCourse(Guid id, int module)
        {
            return Ok();
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
