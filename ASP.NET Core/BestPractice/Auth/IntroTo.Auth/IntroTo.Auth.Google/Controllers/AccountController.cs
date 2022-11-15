using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace IntroTo.Auth.Google.Controllers;

[ApiController]
public class AccountController : Controller
{
    [HttpGet("login")]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties 
        { 
            RedirectUri = $"/signin-google",
            Items =
            {
                { "LoginProvider", GoogleDefaults.AuthenticationScheme }
            },
            AllowRefresh = true
        };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("signin-google")]
    public async Task<IActionResult> GoogleResponseAsync()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (result.Principal?.Identities?.Any() ?? false)
        {
            var claims = result.Principal.Identities.FirstOrDefault()   
                            .Claims.Select(x => new {
                                x.Issuer,
                                x.OriginalIssuer,
                                x.Type,
                                x.ValueType
                            });
            return Json(claims);
        }
        return BadRequest();
    }
}
