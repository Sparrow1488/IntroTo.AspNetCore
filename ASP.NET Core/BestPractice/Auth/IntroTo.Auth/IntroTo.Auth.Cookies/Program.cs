using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Pay More Attention To: 
// - AuthenticationService
// - CookieAuthenticationHandler
// - AuthenticationHandler

builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = "default";
        opt.DefaultChallengeScheme = "default";
    })
    .AddCookie("default");

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.MapGet("/secret", () => "TOP SECRET")
    .RequireAuthorization();

app.MapGet("/login", async (HttpContext ctx) =>
{
    var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
    {
        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Name, "username")
    }, "default"));
    await ctx.SignInAsync("default", user);
});

app.Run();