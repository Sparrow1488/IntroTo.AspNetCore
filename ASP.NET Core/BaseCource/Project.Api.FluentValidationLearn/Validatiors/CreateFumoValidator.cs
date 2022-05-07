using FluentValidation;
using Project.Api.FluentValidationLearn.ViewModels;

namespace Project.Api.FluentValidationLearn.Validatiors
{
    public class CreateFumoValidator : AbstractValidator<CreateFumoViewModel>
    {
        public CreateFumoValidator()
        {
            RuleFor(p => p.Price).NotEmpty().GreaterThan(0);
            RuleFor(p => p.Height).NotEmpty().GreaterThan(0);
            RuleFor(p => p.Article).NotEmpty().Length(0, 25);
            RuleFor(p => p.Tags).NotNull();
        }
    }
}
