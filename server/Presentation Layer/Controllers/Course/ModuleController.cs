using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
namespace CodeCombat.Controllers;
    [ApiController]
    [Route("Course/{id}")]
    public class ModuleController : ControllerBase
    {
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
        [HttpPatch]
        [Route("{module}")]
        public async Task<IActionResult> EditModule(Guid id, int module, JObject obj)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> PostModule(Guid id)
        {
            return Ok();
        }
    }
