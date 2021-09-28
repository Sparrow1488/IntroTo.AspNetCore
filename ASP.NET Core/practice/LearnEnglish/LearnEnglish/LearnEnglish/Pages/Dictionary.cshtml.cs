using LearnEnglish.Database;
using LearnEnglish.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnEnglish.Pages
{
    public class DictionaryModel : PageModel
    {
        private readonly DictionariesDbContext _db;
        public string lastWord;
        public DictionaryModel(DictionariesDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            var dic = new WordsDictionary();
            dic.Items.Add(new Word() { Value = "Happy", Translate = "—частливый" });
            var succDic = _db.Dictionaries.Add(dic);
            _db.SaveChanges();

            if (succDic != null)
            {
                var word = succDic.Entity.Items[0];
                lastWord = word.Value ?? "";
            }
        }
    }
}
