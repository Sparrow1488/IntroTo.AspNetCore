using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IntroTo.Auth.Jwt.Services;

public interface IJwtTokenFactory
{
    JwtSecurityToken CreateToken(ICollection<Claim> claims);
}
