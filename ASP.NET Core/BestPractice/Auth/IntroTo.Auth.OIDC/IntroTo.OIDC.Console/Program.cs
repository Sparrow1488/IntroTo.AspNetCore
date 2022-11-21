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

var tokens = await apiClient.RequestTokenAsync(new TokenRequest
{
    Address = discovery.TokenEndpoint,
    ClientId = "ConsoleClient",
    ClientSecret = "1488",
    GrantType = "authorization_code"
});

Console.WriteLine(tokens.Json);