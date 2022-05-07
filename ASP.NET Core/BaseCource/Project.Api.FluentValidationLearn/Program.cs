using FluentValidation;
using FluentValidation.AspNetCore;
using Project.Api.FluentValidationLearn.Extensions;
using Project.Api.FluentValidationLearn.Validatiors;
using Project.Api.FluentValidationLearn.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt => opt.AllowEmptyInputInBodyModelBinding = true)
                .AddFluentValidation()
                .UseCustomValidationResult();

builder.Services.AddTransient<IValidator<CreateFumoViewModel>, CreateFumoValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
