using LearnEnglish.Database;
using LearnEnglish.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> OnPostAddWord(string wordValue, string wordTranslate, string wordTranscription, int dictionaryId)
        {
            IActionResult actionResult = new RedirectToPageResult("Profile");
            if (IsNotNullRange(new string[]{ wordValue, wordTranslate}) && dictionaryId > 0)
            {
                var newWord = new Word()
                {
                    Value = wordValue,
                    Translate = wordTranslate,
                    Transcription = string.IsNullOrWhiteSpace(wordTranscription) || wordTranscription == null ? "[ ]" : wordTranscription
                };
                var dictionaryFromDb = _db.Dictionaries.Where(dict => dict.Id == dictionaryId).FirstOrDefault();
                if(dictionaryFromDb != null)
                {
                    dictionaryFromDb.Items.Add(newWord);
                    _db.Update(dictionaryFromDb);
                    await _db.SaveChangesAsync();
                }
                actionResult = new RedirectToPageResult("Dictionary", new { id= dictionaryId });
            }
            return actionResult;
        }


        private bool IsNotNullRange(string[] values)
        {
            bool output = true;
            if (values != null && values.Length > 0)
            {
                foreach (var item in values)
                {
                    if (item == null)
                        output = false;
                    if (!output)
                        break;
                }
            }
            return output;
        }
    }
}
