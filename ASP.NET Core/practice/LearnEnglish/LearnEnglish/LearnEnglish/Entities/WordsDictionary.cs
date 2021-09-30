using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Entities
{
    public class WordsDictionary
    {
        [Key]
        public int Id { get; set; }
        public List<Word> Items { get; set; } = new List<Word>();
        public Profile Profile { get; set; }
    }
}
