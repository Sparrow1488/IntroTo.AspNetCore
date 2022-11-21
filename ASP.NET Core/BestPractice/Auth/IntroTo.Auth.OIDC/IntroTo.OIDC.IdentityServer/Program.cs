using IdentityServer4;
using IntroTo.OpenIdConnect.Authentication.Handlers;
using IntroTo.OpenIdConnect.Authentication.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer(options => {
        options.UserInteraction.LoginUrl = "/authentication/login";
        options.Endpoints.EnableUserInfoEndpoint = true;

        // Optional
        options.Authentication.CookieLifetime = TimeSpan.FromMinutes(10);
        options.Authentication.CookieSlidingExpiration = true;
        options.Authentication.CookieSameSiteMode = SameSiteMode.Lax;
    })
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddInMemoryClients(IdentityConfiguration.GetClients())
    .AddInMemoryIdentityResources(IdentityConfiguration.GetIdentityResources())
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication(IdentityServerConstants.DefaultCookieAuthenticationScheme)
    .AddSteam(options => {
       options.SignInScheme = IdentityServerConstants.DefaultCookieAuthenticationScheme;
       options.ApplicationKey = "E4A4DCD48003634B44DC56B0DF7F6641";
       options.Events.OnAuthenticated += Authentication.OnAuthentication;
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

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();