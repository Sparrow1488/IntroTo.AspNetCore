using System.Security.Claims;
using IntroTo.Auth.Schemas.Handlers;
using IntroTo.Auth.Schemas.Permissions;
using IntroTo.Auth.Schemas.Schemas;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(ApiSchemes.VisitorAuthenticationScheme)
    .AddCookie(ApiSchemes.LocalAuthenticationScheme, opt => 
        opt.LoginPath = "/login-local")
    .AddScheme<CookieAuthenticationOptions, LocalAuthenticationHandler>(
        ApiSchemes.VisitorAuthenticationScheme, x=> {});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(ApiPolicies.NamedUser, policyBuilder =>
    {
        policyBuilder.RequireAuthenticatedUser();
        policyBuilder.AddAuthenticationSchemes(
            ApiSchemes.LocalAuthenticationScheme,
            ApiSchemes.VisitorAuthenticationScheme);
        policyBuilder.RequireClaim(ClaimTypes.Name);
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!").RequireAuthorization();

app.MapGet("/me", async ctx =>
{
    var name = ctx.User.FindFirstValue(ClaimTypes.Name);
    await ctx.Response.WriteAsync($"Hello, {name}!");
}).RequireAuthorization(ApiPolicies.NamedUser);

app.MapGet("/login-local", async ctx =>
{
    var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Name, "Valentin")
    };
    var identity = new ClaimsIdentity(claims, ApiSchemes.LocalAuthenticationScheme);
    var user = new ClaimsPrincipal(identity);
        
    await ctx.SignInAsync(ApiSchemes.LocalAuthenticationScheme, user, new AuthenticationProperties
    {
        RedirectUri = "/me"
    });
});

app.Run();