using FluentValidation;

namespace PlanA_Assessment.Application.Features.Products.Commands.SearchProduct
{
    public class SearchCommandValidator : AbstractValidator<SearchProductCommand>
    {
        public SearchCommandValidator()
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
