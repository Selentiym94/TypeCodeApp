using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }


        [HttpGet("/health")]
        public IActionResult HelthCheck()
        {
            return Ok();
        }

    }
}