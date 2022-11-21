using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IntroTo.OpenIdConnect.Authentication.Configurations;

public static class IdentityConfiguration
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("console", new []
            {
                "client_data", "profile", "openid"
            }),
            new ApiScope("webclient", new []
            {
                "client_data", "profile", "openid", "email"
            }),
        };
    
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
                    new Secret("1488".ToSha256())
                },
                
                AllowedGrantTypes = GrantTypes.Code,
                AllowAccessTokensViaBrowser = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "client_data"
                },
                RedirectUris = { "https://localhost:5001/signin-oidc" },
            },
            
            new Client {
                ClientId = "ConsoleClient",
                ClientSecrets = {
                    new Secret("1488".ToSha256())
                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "console" }
            }
        };
}