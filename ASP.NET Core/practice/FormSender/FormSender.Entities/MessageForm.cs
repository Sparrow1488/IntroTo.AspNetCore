using System;

namespace FormSender.Entities
{
    public class MessageForm
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
