using AutoMapper;
using MediatR;
using PlanA_Assessment.Application.Contracts;
using PlanA_Assessment.Application.Features.Products.Queries.GetProductList;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlanA_Assessment.Application.Features.Categorys.Queries.GetCategoryList
{
    public class GetCategorysListQueryHandler : IRequestHandler<GetCategorysListQuery, List<GetCategorysListViewModel>>
    {
        private readonly ICategoryRepository _CategorysRepository;
        private readonly IMapper _mapper;

        public GetCategorysListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _CategorysRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<GetCategorysListViewModel>> Handle(GetCategorysListQuery request, CancellationToken cancellationToken)
        {
            var allCategorys = await _CategorysRepository.GetAllCategoryAsync();
            return _mapper.Map<List<GetCategorysListViewModel>>(allCategorys);
        }
    }
}
