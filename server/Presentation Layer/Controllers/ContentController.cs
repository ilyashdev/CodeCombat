using CodeCombat.Application_Layer.Services.IService;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.AspNetCore.Mvc;
namespace CodeCombat.Controllers;
    [ApiController]
    [Route("[controller]/{type}")]
    public class ContentController : ControllerBase
    {
        private readonly ICourseService _courseService;

    public ContentController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    public int TelegramId = 0;
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContent(string type, Guid id)
        {
            return Ok();
        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> EditCourse(string type,Guid id, ContentRequest request)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetContentList(string type,[FromQuery]int page, [FromBody]ContentListRequest? request)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContent(string type,ContentRequest request)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteContent(string type,Guid id)
        {
            return Ok();
        }
    }
