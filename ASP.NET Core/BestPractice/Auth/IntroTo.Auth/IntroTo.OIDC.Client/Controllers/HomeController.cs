﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntroTo.OIDC.Client.Controllers;

[ApiController, Route("[controller]")]
public class HomeController : Controller
{
    [HttpGet("claims"), Authorize]
    public IActionResult GetClaims()
    {
        var claims = User.Identities.SelectMany(x => x.Claims);
        return Json(claims.Select(x => $"{x.Type}: {x.Value}"));
    }
}