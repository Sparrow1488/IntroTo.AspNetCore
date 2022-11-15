using IntroTo.Auth.Jwt.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IntroTo.Auth.Jwt.Services;

public class JwtTokenFactory : IJwtTokenFactory
{
    public JwtSecurityToken CreateToken(ICollection<Claim> claims)
    {
        return new JwtSecurityToken(
            issuer: JwtConfiguration.Issuer,
            audience: JwtConfiguration.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.Add(JwtConfiguration.ExpiresTime),
            signingCredentials: new SigningCredentials(JwtConfiguration.GetSecurityKey(), SecurityAlgorithms.HmacSha256));
    }
}
