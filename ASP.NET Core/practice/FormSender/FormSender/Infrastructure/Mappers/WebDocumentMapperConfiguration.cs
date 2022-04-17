using FormSender.Entities;
using FormSender.Infrastructure.Mappers.Base;
using FormSender.ViewModels;

namespace FormSender.Infrastructure.Mappers
{
    public class WebDocumentMapperConfiguration : MapperConfigurationBase
    {
        public WebDocumentMapperConfiguration()
        {
            CreateMap<WebDocument, WebDocumentViewModel>().ReverseMap();
        }
    }
}
