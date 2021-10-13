using LearnEnglish.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace LearnEnglish.Pages.Profile
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Entities.Profile Profile { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int profileId)
        {
            var profile = _db.Profiles.Where(profile => profile.Id == profileId).FirstOrDefault();
            if (profile != null)
            {
                Profile = profile;
            }
        }
    }
}
