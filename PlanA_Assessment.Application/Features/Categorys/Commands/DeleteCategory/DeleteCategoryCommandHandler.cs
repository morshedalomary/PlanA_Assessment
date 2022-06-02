
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PlanA_Assessment.Application.Contracts;

namespace PlanA_Assessment.Application.Features.Categorys.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var post = await _categoryRepository.GetByIdAsync(request.ID);

            await _categoryRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }

}
