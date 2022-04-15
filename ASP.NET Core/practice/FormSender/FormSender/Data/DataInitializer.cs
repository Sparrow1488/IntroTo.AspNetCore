using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FormSender.Data
{
    public static class DataInitializer
    {
        public static async Task InitializeAsync(IServiceProvider provider)
        {
            var scope = provider.CreateScope();
            using (var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>())
            {
                var dbCreator = dbContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                var exists = await dbCreator.ExistsAsync();
                if (exists)
                {
                    await dbContext.Database.MigrateAsync();
                }
            }
        }
    }
}
