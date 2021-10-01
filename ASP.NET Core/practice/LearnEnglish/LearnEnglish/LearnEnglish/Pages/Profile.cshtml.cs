using LearnEnglish.Database;
using LearnEnglish.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace LearnEnglish.Pages
{
    public class ProfileModel : PageModel
    {
        public List<WordsDictionary> UserDictionaries { get; set; } = new List<WordsDictionary>();
        public string UserLogin { get; set; } = string.Empty;
        private readonly ApplicationDbContext _db;
        public ProfileModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            string cookie = Request.Cookies["Login"];
            var view = new PageResult();
            IActionResult result = view;
            if (string.IsNullOrWhiteSpace(cookie))
                result = RedirectToPage("Login");
            else
            {
                UserLogin = cookie;
                UserDictionaries = GetUserDictionaries();
            }
            return result;
        }
        private List<WordsDictionary> GetUserDictionaries()
        {
            var profile = _db.Profiles.Where(p => p.Login == UserLogin).FirstOrDefault();
            var findDictionaries = new List<WordsDictionary>();
            if (profile != null)
            {
                var dictionary = _db.Dictionaries.Where(d => d.Profile.Id == profile.Id).ToList();
                if (dictionary != null)
                    findDictionaries = dictionary;
            }
            return findDictionaries;
        }
    }
}
