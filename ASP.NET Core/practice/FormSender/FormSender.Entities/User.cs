using FormSender.Entities.Abstractions;

namespace FormSender.Entities
{
    public class User : Identity
    {
        public string Login { get; set; }
    }
}
