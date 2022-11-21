using IdentityModel.Client;

Console.WriteLine("Hello, World!");

using var client = new HttpClient();
var discovery = await client.GetDiscoveryDocumentAsync("https://localhost:3001");
if (discovery.IsError)
{
    Console.WriteLine(discovery.Error);
}

var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = discovery.TokenEndpoint,

    ClientId = "ConsoleClient",
    ClientSecret = "1488",
    Scope = "console"
});

if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return;
}

Console.WriteLine(tokenResponse.Json);
Console.WriteLine();


using var apiClient = new HttpClient();
apiClient.SetBearerToken(tokenResponse.AccessToken);
var info = await apiClient.GetUserInfoAsync(new UserInfoRequest()
{
    Address = discovery.UserInfoEndpoint,

    ClientId = "ConsoleClient",
    ClientSecret = "1488",
    Token = tokenResponse.IdentityToken
});
Console.WriteLine(info.Json);
// var response = await apiClient.GetStringAsync("https://localhost:5001/home/claims");
// Console.WriteLine(response);