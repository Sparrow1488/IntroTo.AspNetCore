using LearnEnglish.Database;
using LearnEnglish.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnEnglish.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGetAsync()
        {
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();

            var profile = new Profile();
            profile.Login = "Sparrow";
            profile.Password = "1488";
            profile.Dictionaries = new List<WordsDictionary>();
            profile.Dictionaries.Add(new WordsDictionary());
            var res = _db.Profiles.Add(profile);
            await _db.SaveChangesAsync();
        }
    }
}
