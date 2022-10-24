using IntroTo.Auth.Jwt.Enums;
using IntroTo.Auth.Jwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace IntroTo.Auth.Jwt.Controllers;

[ApiController]
[Route("values")]
public class ValuesController : Controller
{
    private readonly IUsersProvider _usersProvider;

    public ValuesController(
        IUsersProvider usersProvider)
    {
        _usersProvider = usersProvider;
    }

    [HttpGet("users")]
    [Authorize(Roles = AppClaims.User.Admin)]
    public IActionResult GetUsers()
    {
        return Json(new
        {
            User.Identity?.Name,
            Role = User.Claims.Single(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value,
            Users = _usersProvider.GetUsers().Select(x => new
            {
                x.Name,
                x.Role
            })
        });
    }
}
