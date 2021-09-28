using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Entities
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Translate { get; set; }
        public string Transcription { get; set; }
        public string Category { get; set; }
    }
}
