using LearnEnglish.Database;
using LearnEnglish.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace LearnEnglish.Pages
{
    public class DictionaryModel : PageModel
    {
        public DictionaryModel(ApplicationDbContext db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;
        public string inputWord;
        public WordsDictionary Dictionary { get; set; }
        public List<Word> WordsList { get; set; } = new List<Word>();
        public Word Word { get; set; }

        public IActionResult OnGet(int id)
        {
            IActionResult result = new RedirectToPageResult("Index");
            if (id > 0)
            {
                var dictionary = _db.Dictionaries.Where(dic => dic.Id == id).FirstOrDefault();
                if (dictionary != null)
                {
                    Dictionary = dictionary;
                    WordsList = _db.Words.Where(word => word.Dictionary.Id == Dictionary.Id).ToList();
                    result = new PageResult();
                }
            }
            return result;
        }

        public void OnPost(string word, string translate)
        {
            inputWord = word;
        }
    }
}
