using FormSender.Entities;
using FormSender.Infrastructure.Mappers.Base;
using FormSender.ViewModels;

namespace FormSender.Infrastructure.Mappers
{
    public class ContentMapperConfiguration : MapperConfigurationBase
    {
        public ContentMapperConfiguration()
        {
            CreateMap<Content, ContentViewModel>().ReverseMap();
        }
    }
}
