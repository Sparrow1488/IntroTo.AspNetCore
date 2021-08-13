using Microsoft.AspNetCore.Mvc;

namespace _2.DbWork.Controllers
{
    [Route("/product")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
