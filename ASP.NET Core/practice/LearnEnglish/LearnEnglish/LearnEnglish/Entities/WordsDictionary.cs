using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Entities
{
    public class WordsDictionary
    {
        [Key]
        public int Id { get; set; }
        public List<Word> Items { get; set; } = new List<Word>();
    }
}
