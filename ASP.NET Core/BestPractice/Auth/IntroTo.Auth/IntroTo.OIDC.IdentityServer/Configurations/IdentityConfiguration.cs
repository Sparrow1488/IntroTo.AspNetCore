using IdentityServer4;
using IdentityServer4.Models;

namespace IntroTo.OpenIdConnect.Configurations;

public static class IdentityConfiguration
{
    public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    
    // public static IEnumerable<ApiResource> GetApiResources() =>
    //     new List<ApiResource> {
    //         new ApiResource(name: "client", displayName: "Client API",
    //             userClaims: new[] { "client.read", "client.write" })
    //     };

    public static IEnumerable<Client> GetClients() =>
        new List<Client> {
            new Client {
                ClientId = "ClientAPI",
                ClientSecrets = {
                    new Secret("ClientAPISecret")
                },
                
                AllowedGrantTypes = GrantTypes.Implicit,
                
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                RedirectUris = { "https://localhost:5001/signin-oidc" }
            }
        };
}