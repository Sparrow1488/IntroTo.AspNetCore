using LearnEnglish.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LearnEnglish.Pages.Shared
{
    public class LayoutModel : PageModel
    {
        public string UserLogin { get; set; } = string.Empty;
        public bool IsAuth {
            get {
                bool auth = false;
                if (Request != null && Request.Cookies.ContainsKey("Login"))
                {
                    auth = true;
                    UserLogin = Request.Cookies["Login"];
                }
                return auth;
            }
        }
        public LayoutModel()
        {
        }
    }
}
