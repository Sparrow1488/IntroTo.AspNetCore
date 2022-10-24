namespace IntroTo.Auth.Jwt.Enums;

public class AppClaims
{
    public class Api
    {
        public const string AuthenticationType = "JwtToken";
    }

    public class User
    {
        public const string Admin = "claims.user.admin";
        public const string Default = "claims.user.default";
    }
}
