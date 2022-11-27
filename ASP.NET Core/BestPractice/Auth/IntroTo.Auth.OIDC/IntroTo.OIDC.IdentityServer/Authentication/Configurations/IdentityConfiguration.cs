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
            new("console", new []
            {
                "client_data", "profile", "openid"
            })
        };
    
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new("client_info", new[]
            {
                "client_name", 
                "client_country", 
                ClaimTypes.Role, 
                IdentityServerConstants.StandardScopes.Email
            })
        };
    
    public static IEnumerable<Client> Clients =>
        new List<Client> {
            new()
            {
                ClientId = "WebAPI",
                ClientSecrets = {
                    new Secret("1488".ToSha256())
                },
                
                AllowedGrantTypes = GrantTypes.Code,
                AllowAccessTokensViaBrowser = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true, // To Generate Refresh Token
                RefreshTokenUsage = TokenUsage.ReUse,
                
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "client_info"
                },
                RedirectUris = { "https://localhost:5001/signin-oidc" },
            },
            
            new()
            {
                ClientId = "ConsoleClient",
                ClientSecrets = {
                    new Secret("1488".ToSha256())
                },
                AllowedGrantTypes = GrantTypes.Code,
                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "console"
                }
            }
        };
}