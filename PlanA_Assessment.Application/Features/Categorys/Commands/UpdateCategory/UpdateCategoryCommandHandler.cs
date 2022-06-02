using AutoMapper;

using MediatR;
using PlanA_Assessment.Application.Contracts;
using PlanA_Assessment.Application.Features.Categorys.Commands.UpdateCategory;
using PlanA_Assessment.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace PlanA_Assessment.Application.Features.Category.Commands.UpdateProduct
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IAsyncRepository<PlanA_Assessment.Domain.Category> _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(IAsyncRepository<PlanA_Assessment.Domain.Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            PlanA_Assessment.Domain.Category category = _mapper.Map<PlanA_Assessment.Domain.Category>(request);

            await _categoryRepository.UpdateAsync(category);

            return Unit.Value;
        }
    }
}
