using System.Security.Claims;
using IdentityServer4.Test;

namespace IntroTo.OpenIdConnect.Configurations;

public static class MockConfiguration
{
    public static IEnumerable<TestUser> GetUsers() =>
        new List<TestUser> {
            new TestUser
            {
                SubjectId = "1",
                Username = "Valentin",
                Password = "1234",
                
                Claims = new List<Claim>
                {
                    new("name", "Valentin"),
                    new("email", "val@gmail.com"),
                    new("role", "admin")
                }
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "Yuri",
                Password = "1234",
                
                Claims = new List<Claim>
                {
                    new("name", "Yuri"),
                    new("email", "yuti@yandex.ru"),
                    new("role", "user")
                }
            },
        };
}