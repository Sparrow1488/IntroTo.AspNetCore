using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IntroTo.Auth.Jwt.Configuration;

public class JwtConfiguration
{
    public const string Audience = "[Client]IntroTo.Auth.Jwt";
    public const string Issuer = "[Server]IntroTo.Auth.Jwt";
    public static readonly TimeSpan ExpiresTime = TimeSpan.FromHours(1);

    private static readonly string _securityKey = "super_secret_security_key";

    public static SymmetricSecurityKey GetSecurityKey()
        => new(Encoding.ASCII.GetBytes(_securityKey));
}
