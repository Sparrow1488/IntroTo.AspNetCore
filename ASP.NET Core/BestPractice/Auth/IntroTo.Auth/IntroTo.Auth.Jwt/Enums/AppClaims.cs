namespace IntroTo.Auth.Jwt.Enums;

public static class AppClaims
{
    public static class Api
    {
        public const string AuthenticationType = "JwtToken";
    }

    public static class User
    {
        public const string Admin = "claims.user.admin";
        public const string Default = "claims.user.default";
    }
}
