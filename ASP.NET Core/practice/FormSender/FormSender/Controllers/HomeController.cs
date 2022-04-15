using Microsoft.AspNetCore.Mvc;

namespace FormSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { message = "ok" });
        }
    }
}
