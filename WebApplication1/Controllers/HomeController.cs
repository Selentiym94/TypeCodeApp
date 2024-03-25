using Microsoft.AspNetCore.Mvc;
using WebApplication1.Logic.Processors;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly DataProcessor _dataProcessor;
        public HomeController(DataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }


        [HttpGet("/health")]
        public IActionResult HelthCheck()
        {
            return Ok();
        }

    }
}