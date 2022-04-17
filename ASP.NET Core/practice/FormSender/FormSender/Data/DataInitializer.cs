using FormSender.Entities;
using FormSender.Entities.Abstractions;
using FormSender.Entities.Enums;
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
                if (!exists)
                {
                    await dbContext.Database.MigrateAsync();
                    var messageForm = CreateFirstMessageForm();
                    await dbContext.MessageForms.AddAsync(messageForm);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private static MessageForm CreateFirstMessageForm()
        {
            var formContent = new Content()
            {
                Title = "Просто.",
                Text = "Первое сообщения, автоматически созданное при инициализации данного проекта",
                Documents = new[] { new WebDocument()
                        {
                            Url = "https://cdn.kodixauto.ru/media//media/image/6257b93e825ab09b2f4ba19b",
                            Extension = ".jpeg",
                            Type = SourceType.Image,
                            CreatedAt = DateTime.Now
                        }}
            };
            var messageForm = new MessageForm()
            {
                Content = formContent,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
            };
            return messageForm;
        }
    }
}
