using LearnEnglish.Database;
using LearnEnglish.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Pages
{
    public class DictionaryModel : PageModel
    {
        private readonly DictionariesDbContext _db;
        public string lastWord;
        public Word word;
        public string inputWord;
        public DictionaryModel(DictionariesDbContext db)
        {
            _db = db;
        }
        public async Task OnGetAsync()
        {
            //var firstDictionary = _db.Dictionaries.Where(dict => dict.Id == 1).FirstOrDefault();
            //if(firstDictionary != null)
            //{
            //    firstDictionary.Items.Add(new Word() { Value = "Reject", Translate = "Отклонять" });
            //    var succDic = _db.Dictionaries.Update(firstDictionary);
            //    await _db.SaveChangesAsync();

            //    if (succDic != null)
            //        word = succDic.Entity.Items.Last();
            //}
        }

        public async Task OnPostAsync(string word, string translate)
        {
            inputWord = word;
        }
    }
}
