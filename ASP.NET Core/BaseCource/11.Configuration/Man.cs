using System.Collections.Generic;

namespace _11.Configuration
{
    public class Man
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Skills { get; set; }
        public Company Company { get; set; }
    }
}
