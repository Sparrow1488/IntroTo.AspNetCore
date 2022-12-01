using IntroTo.SignalR.Mvc.Models;

namespace IntroTo.SignalR.Mvc.Services;

public class UserManager
{
    ICollection<User> Users => new[]
    {
        new User() { Id = 1, Name = "Valentin" },
        new User() { Id = 2, Name = "Sparrow" },
        new User() { Id = 3, Name = "Ilya" }
    };

    public User? GetUser(int id)
    {
        return Users.FirstOrDefault(x => x.Id == id);
    }
}