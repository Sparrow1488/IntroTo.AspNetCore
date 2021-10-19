using LearnEnglish.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LearnEnglish.Pages
{
    public class SignupModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public SignupModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnPostAsync(string email, string login, string password)
        {
            var profile = new LearnEnglish.Entities.Profile
            {
                Login = login,
                Email = email,
                Password = password
            };
            await _db.Profiles.AddAsync(profile);
            await _db.SaveChangesAsync();
            Response.Cookies.Append("Login", login);
            return new RedirectToPageResult("Profile/Index");
        }
    }
}
