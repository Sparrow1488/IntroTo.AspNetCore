using FormSender.Entities.Enums;

namespace FormSender.Entities.Abstractions
{
    public class WebDocument : Identity
    {
        public string Url { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public SourceType Type { get; set; }
    }
}
