using AuthorizationNETCore.Database.Entities;
using System;

namespace AuthorizationNETCore.Database.Database
{
    internal static class DatabaseInitializer
    {
        public static void Init(IServiceProvider provider)
        {
            var db = (ApplicationDbContext)provider.GetService(typeof(ApplicationDbContext));
            var user = new User() { Name = "asd", Password = "1234" };
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
