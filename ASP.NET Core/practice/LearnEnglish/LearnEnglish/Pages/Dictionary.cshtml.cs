using LearnEnglish.Database;
using LearnEnglish.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LearnEnglish.Pages
{
    public class DictionaryModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public string lastWord;
        public Word word;
        public string inputWord;
        public DictionaryModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGetAsync()
        {

            //var profile = _db.Profiles.FirstOrDefault();
            //if (profile != null)
            //{
            //    var words = new List<Word>() { new Word() { Value = "Pizza", Translate = "пицца" } };
            //    profile.Dictionaries = new List<WordsDictionary>();
            //    profile.Dictionaries.Add(new WordsDictionary() { Items = words });
            //    var succDic = _db.Profiles.Update(profile);
            //    await _db.SaveChangesAsync();
            //}
        }

        public async Task OnPostAsync(string word, string translate)
        {
            inputWord = word;
        }
    }
}
