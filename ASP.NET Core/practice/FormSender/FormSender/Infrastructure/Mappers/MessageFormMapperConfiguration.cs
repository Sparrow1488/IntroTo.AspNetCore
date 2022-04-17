using FormSender.Entities;
using FormSender.Infrastructure.Mappers.Base;
using FormSender.ViewModels;

namespace FormSender.Infrastructure.Mappers
{
    public class MessageFormMapperConfiguration : MapperConfigurationBase
    {
        public MessageFormMapperConfiguration()
        {
            CreateMap<MessageForm, MessageFormViewModel>().ReverseMap();
        }
    }
}
