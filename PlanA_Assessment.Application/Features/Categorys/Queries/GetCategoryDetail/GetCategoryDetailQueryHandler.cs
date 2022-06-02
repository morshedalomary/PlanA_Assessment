using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PlanA_Assessment.Application.Features.Categorys.Queries.GetCategoryDetail;
using PlanA_Assessment.Application.Contracts;

namespace PlanA_Assessment.Application.Features.Category.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, GetCategoryDetailViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryDetailQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<GetCategoryDetailViewModel> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId);

            return _mapper.Map<GetCategoryDetailViewModel>(category);
        }
    }
}
