using CodeCombat.Application_Layer.Service;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.AspNetCore.Mvc;
namespace CodeCombat.Controllers;
    [ApiController]
    [Route("[controller]/{type}")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;

    public ContentController(IContentService contentService)
    {
        _contentService = contentService;
    }
    public int TelegramId = 0;
        [HttpGet]
        public async Task<IActionResult> GetContentList(string type,[FromQuery]int page, [FromQuery]ICollection<string>? tags)
        {
            return Ok(await _contentService.GetListAsync(type,page,tags));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteContent(Guid id)
        {
            var telegramId = 0;
            await _contentService.DeleteAsync(telegramId,id);
            return Ok();
        }
    }
