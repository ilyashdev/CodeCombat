using Microsoft.AspNetCore.Mvc;
using CodeCombat.Contracts;
using CodeCombat.Services;
namespace CodeCombat.Controllers;
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        public CourseController()
        {

        }
        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] CoursePostRequest request)
        {
            return Ok(request);
        }
    }
