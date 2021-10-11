using LearnEnglish.Database;
using LearnEnglish.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace LearnEnglish.Pages.Training
{
    public class RandomizerModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<WordsDictionary> Dictionaries { get; set; } = new List<WordsDictionary>();

        public RandomizerModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            IActionResult result = new RedirectResult("../Login");
            if(Request.Cookies.TryGetValue("Login", out string login))
            {
                Dictionaries = _db.Dictionaries.Where(user => user.Profile.Login == login).ToList();
                result = new PageResult();
            }
            return result;
        }
    }
}
