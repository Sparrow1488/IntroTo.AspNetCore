using FormSender.Entities.Abstractions;
using System.Collections.Generic;

namespace FormSender.Entities
{
    public class Content : Identity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IEnumerable<WebDocument> Documents { get; set; }
        public MessageForm MessageForm { get; set; }
    }
}
