using AuthorizationNETCore.Database.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;

namespace AuthorizationNETCore.Database.Database
{
    internal static class DatabaseInitializer
    {
        public static void Init(IServiceProvider provider)
        {
            var userManager = (UserManager<AppUser>)provider.GetService(typeof(UserManager<AppUser>));
            var user = new AppUser() { UserName = "asd" };
            var result = userManager.CreateAsync(user, "1234").GetAwaiter().GetResult();
            if (result.Succeeded)
                userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Administrator"));
            else throw new Exception("Не удалось создать пользователя");
        }
    }
}
