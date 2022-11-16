using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntroTo.OpenIdConnect.Controllers;

[ApiController, Route("[controller]")]
public class HomeController : Controller
{
    [HttpGet("protected"), Authorize]
    public IActionResult GetProtected() => Ok("Ok");
}