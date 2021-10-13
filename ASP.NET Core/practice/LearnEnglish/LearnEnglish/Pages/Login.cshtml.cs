using LearnEnglish.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace LearnEnglish.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public LoginModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnPost(string login, string password)
        {
            string redirectToPage = "Login";
            var all = _db.Profiles;
            var foundProfile = _db.Profiles.Where(profile => profile.Login == login && profile.Password == password).FirstOrDefault();
            if (foundProfile != null)
            {
                Response.Cookies.Append("Login", foundProfile.Login);
                Response.Cookies.Append("Identy", foundProfile.Id.ToString());
                redirectToPage = "Profile/Index";
            }
            return RedirectToPage(redirectToPage);
        }
    }
}
