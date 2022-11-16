using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;

namespace IntroTo.OpenIdConnect.Authentication.Configurations;

public static class IdentityConfiguration
{
    public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource("client_data", new[]
            {
                "client_name", "client_country", ClaimTypes.Role
            })
        };
    
    public static IEnumerable<Client> GetClients() =>
        new List<Client> {
            new Client {
                ClientId = "WebAPI",
                ClientSecrets = {
                    new Secret("my-super-duper-client-secret")
                },
                
                AllowedGrantTypes = GrantTypes.Implicit,
                
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "client_data"
                },
                RedirectUris = { "https://localhost:5001/signin-oidc" }
            }
        };
}