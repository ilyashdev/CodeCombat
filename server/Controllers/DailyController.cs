using Microsoft.AspNetCore.Mvc;
using CodeCombat.Contracts;
using CodeCombat.Services;
using Newtonsoft.Json.Linq;
using System.Text;
namespace CodeCombat.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class DailyController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DailyController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> GetDaily()
        {
            using (FileStream fstream = new FileStream(_webHostEnvironment.WebRootPath + "/daily.json", FileMode.OpenOrCreate))
            {
                byte[] buffer = new byte[fstream.Length];
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                return Ok(textFromFile);
            }
        }

    }
