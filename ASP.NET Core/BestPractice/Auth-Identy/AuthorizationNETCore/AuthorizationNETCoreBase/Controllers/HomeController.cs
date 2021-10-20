using Microsoft.AspNetCore.Mvc;

namespace AuthorizationNETCoreBase.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
