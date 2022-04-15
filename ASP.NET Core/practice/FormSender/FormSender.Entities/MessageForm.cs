using System;
using System.ComponentModel.DataAnnotations;

namespace FormSender.Entities
{
    public class MessageForm
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
