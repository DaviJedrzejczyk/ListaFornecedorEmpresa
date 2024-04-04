using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet("Home")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
