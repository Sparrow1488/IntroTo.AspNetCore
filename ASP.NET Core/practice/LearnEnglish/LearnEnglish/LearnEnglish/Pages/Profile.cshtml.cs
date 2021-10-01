using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnEnglish.Pages
{
    public class ProfileModel : PageModel
    {
        public string Login { get; set; }
        public IActionResult OnGet()
        {
            string cookie = Request.Cookies["Login"];
            var view = new ViewResult()
            {
                ViewName = "Profile"
            };
            IActionResult result = view;
            if (string.IsNullOrWhiteSpace(cookie))
                result = RedirectToPage("Login");
            return result;
        }
    }
}
