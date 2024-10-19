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
        private DateOnly _date;
        private string _daily;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DailyController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> GetDaily()
        {
            if(_date != DateOnly.FromDateTime(DateTime.UtcNow))
            using (FileStream fstream = new FileStream(_webHostEnvironment.WebRootPath + "/daily.json", FileMode.OpenOrCreate))
            {
                byte[] buffer = new byte[fstream.Length];
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                _daily = textFromFile;
                _date = DateOnly.FromDateTime(DateTime.UtcNow);
            }
            return Ok(_daily);
        }

    }
