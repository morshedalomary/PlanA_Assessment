using FluentValidation;

namespace PlanA_Assessment.Application.Features.Categorys.Commands.CreateCategory
{
    public class CreateCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCommandValidator()
        {
         
            
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
