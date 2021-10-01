using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnEnglish.Pages
{
    public class LoginModel : PageModel
    {
        public LoginModel()
        {
        }
        public IActionResult OnPost(string login, string password)
        {
            Response.Cookies.Append("Login", login);
            Response.Cookies.Append("Test", password);
            return RedirectToPage("Profile");
        }
    }
}
