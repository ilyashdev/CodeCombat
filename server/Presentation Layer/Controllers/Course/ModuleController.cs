using System.Text.Json.Nodes;
using CodeCombat.Application_Layer.Service;
using CodeCombat.Presentation_Layer.Contract;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("{module}")]
        public async Task<IActionResult> GetModule(Guid id)
        {
            return Ok(await _moduleService.GetAsync(id));
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
        [HttpPost]
        [Route("{module}")]
        public async Task<IActionResult> TestSolution(Guid id)
        {
            return Ok();
        }
    }
