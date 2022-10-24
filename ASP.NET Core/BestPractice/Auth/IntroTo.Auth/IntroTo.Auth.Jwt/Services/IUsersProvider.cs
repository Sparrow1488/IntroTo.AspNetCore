using IntroTo.Auth.Jwt.Models;

namespace IntroTo.Auth.Jwt.Services;

public interface IUsersProvider
{
    ICollection<User> GetUsers();
}
