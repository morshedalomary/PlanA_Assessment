using FluentValidation;

namespace PlanA_Assessment.Application.Features.Products.Commands.CreateProduct
{
    public class CreateCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            
            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull();
        }
    }
}
