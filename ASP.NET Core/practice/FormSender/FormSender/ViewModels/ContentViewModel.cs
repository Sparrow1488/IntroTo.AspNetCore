using FormSender.Entities.Abstractions;
using System.Collections.Generic;

namespace FormSender.ViewModels
{
    public class ContentViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IEnumerable<WebDocument> Documents { get; set; }
    }
}
