using System;
using System.Linq;

namespace FormSender.Infrastructure.Mappers.Base
{
    public static class MapperRegistration
    {
        private static Type[] GetProfiles()
        {
            var automappers = typeof(Startup).Assembly
                                             .GetTypes()
                                             .Where(type => type.IsAssignableFrom(typeof(IAutoMapper)) &&
                                                            !type.IsAbstract);
            return automappers.ToArray();
        }
    }
}
