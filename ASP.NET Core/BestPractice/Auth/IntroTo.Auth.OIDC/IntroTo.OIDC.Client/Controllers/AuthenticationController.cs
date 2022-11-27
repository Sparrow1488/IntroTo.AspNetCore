using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IntroTo.OIDC.Client.Controllers;

[ApiController, Route("[controller]")]
public class AuthenticationController : Controller
{
    [HttpGet("login")]
    public IActionResult Login(string? returnUrl = "/")
    {
        var properties = new AuthenticationProperties()
        {
            RedirectUri = returnUrl ?? "/",
            IsPersistent = true
        };
        return Challenge(
            properties, 
            "idserver");
    }

    [HttpGet("token")]
    public async Task<string> GetJsonTokenAsync(string tokenName)
    {
        var tokenJson = await HttpContext.GetTokenAsync(tokenName);
        var handler = new JwtSecurityTokenHandler();
        return handler.CanReadToken(tokenJson) 
            ? handler.ReadJwtToken(tokenJson).ToString() 
            : "Null or can't read";
    }
}