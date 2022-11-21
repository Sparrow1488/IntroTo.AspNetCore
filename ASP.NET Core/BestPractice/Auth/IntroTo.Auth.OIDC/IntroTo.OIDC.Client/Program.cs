using System.Security.Claims;
using IntroTo.OIDC.Shared.Schemes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", x => {
        x.RequireClaim(ClaimTypes.Role, "User");
    });
    options.AddPolicy("Admin", x => {
        x.RequireClaim(ClaimTypes.Role, "User");
        x.RequireClaim(ClaimTypes.Role, "Admin");
    });
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/authentication/login";
    })
    .AddOpenIdConnect(CustomIdentityAuthenticationScheme.AuthenticationScheme, options =>
    {
        options.Authority = "https://localhost:3001";
        options.ClientId = "WebAPI";
        options.ClientSecret = "1488";
        
        options.ResponseType = OpenIdConnectResponseType.Code;
        
        options.Scope.Add("client-info");
    });

builder.Services.Configure<RouteOptions>(x => {
    x.LowercaseUrls = true;
    x.LowercaseQueryStrings = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();