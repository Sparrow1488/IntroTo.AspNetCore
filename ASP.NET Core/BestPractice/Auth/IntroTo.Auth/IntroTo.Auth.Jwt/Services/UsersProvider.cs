using IntroTo.Auth.Jwt.Enums;
using IntroTo.Auth.Jwt.Models;

namespace IntroTo.Auth.Jwt.Services;

public class UsersProvider : IUsersProvider
{
    private readonly ICollection<User> _users = new List<User>();

    public UsersProvider()
    {
        _users.Add(new() { Name = "Yuri", Password = "1234", Role = AppClaims.User.Default });
        _users.Add(new() { Name = "Oleg", Password = "1234", Role = AppClaims.User.Admin });
    }

    public ICollection<User> GetUsers() => _users;
}
