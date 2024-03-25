using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Logic.Processors;
using WebApplication1.Logic.Models;

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

        [HttpPost("/user")]
        public async Task<IActionResult> GetUser([FromBody]GetUserRequest body)
        {
            TypeCodeData result =  await _dataProcessor.Get(body.Name).ConfigureAwait(false);
            return Ok(result);
        }


    }
}