using IntroTo.Auth.Jwt.Enums;
using IntroTo.Auth.Jwt.Models;
using IntroTo.Auth.Jwt.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IntroTo.Auth.Jwt.Controllers;

[ApiController]
[Route("auth")]
public class AuthorizationController : Controller
{
    private readonly ICollection<User> _users = new List<User>();
    private readonly IJwtTokenFactory _tokenFactory;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public AuthorizationController(
        IJwtTokenFactory tokenFactory,
        JwtSecurityTokenHandler tokenHandler)
    {
        _users.Add(new() { Name = "Yuri", Password = "1234", Role = AppClaims.User.Default });
        _users.Add(new() { Name = "Oleg", Password = "1234", Role = AppClaims.User.Admin });
        _tokenFactory = tokenFactory;
        _tokenHandler = tokenHandler;
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("me")]
    public IActionResult GetMyInformation()
    {
        return Json(new
        {
            Name = User.Identity?.Name,
            Role = User.Claims.Single(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value
        });
    }

    [HttpPost("token")]
    public IActionResult GetToken(string name, string password)
    {
        var identity = GetClaimsIdentity(name, password);
        if (identity is null)
            return BadRequest("User not found!");

        var token = _tokenFactory.CreateToken(identity.Claims.ToArray());
        var encodedToken = _tokenHandler.WriteToken(token);
        Response.Cookies.Append("Authorization", "Bearer " + encodedToken);

        return Ok(encodedToken);
    }

    private ClaimsIdentity? GetClaimsIdentity(string name, string password)
    {
        var user = _users.SingleOrDefault(x => x.Name == name && x.Password == password);
        if (user is null)
            return null;

        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, user.Name),
            new(ClaimsIdentity.DefaultRoleClaimType, user.Role)
        };

        return new ClaimsIdentity(
            claims, 
            AppClaims.Api.AuthenticationType,
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
    }
}