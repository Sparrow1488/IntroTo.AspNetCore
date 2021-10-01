using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Entities
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string CoverUrl { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<WordsDictionary> Dictionaries { get; set; }
    }
}
