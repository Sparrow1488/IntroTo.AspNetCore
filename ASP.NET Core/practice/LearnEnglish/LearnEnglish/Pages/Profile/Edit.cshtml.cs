using LearnEnglish.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Pages.Profile
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Entities.Profile Profile { get; set; }
        [BindProperty]
        public IFormFile Cover { get; set; }

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
        
        public async Task<IActionResult> OnPostProfileSettings(int id, string description)
        {
            var updatedProfile = _db.Profiles.Where(prof => prof.Id == id).First();
            if(updatedProfile != null)
            {
                updatedProfile.Description = description;
                _db.Update(updatedProfile);
                await _db.SaveChangesAsync();
            }
            return RedirectToPagePermanent("Edit", new { profileId = id });
        }
    }
}
