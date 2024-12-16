using System.Text.Json.Nodes;
using CodeCombat.Application_Layer.Service;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
namespace CodeCombat.Controllers;
    [ApiController]
    [Route("Content/Course/{id}")]
    public class ModuleController : ControllerBase
    {
        private IModuleService _moduleService;

    public ModuleController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    public ModuleController()
        {

        }

        [HttpGet]
        [Route("{module}")]
        public async Task<IActionResult> GetModule(Guid id, int module)
        {
            return Ok();
        }
        
        [HttpDelete]
        [Route("{module}")]
        public async Task<IActionResult> DeleteModule(Guid id, int module)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> PostModule(Guid id,[FromQuery]int? pos,[FromBody]ModuleRequest module)
        {
            await _moduleService.PostAsync(id,0,module,pos);
            return Ok();
        }
    }
