using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/authentication/login";
    })
    .AddOpenIdConnect("idserver", options =>
    {
        options.Authority = "https://localhost:3001";
        options.ClientId = "ClientAPI";
        options.ClientSecret = "ClientAPISecret";
        options.GetClaimsFromUserInfoEndpoint = true;
        
        options.Scope.Add("email");
        options.Scope.Add("client_data");
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