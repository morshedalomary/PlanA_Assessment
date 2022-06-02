using AutoMapper;
using MediatR;
using PlanA_Assessment.Application.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlanA_Assessment.Application.Features.Products.Queries.GetProductListBySearch
{
    public class GetProductsListSearchQueryHandler : IRequestHandler<GetProductsListSearchQuery, List<GetProductsListSearchViewModel>>
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsListSearchQueryHandler(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<GetProductsListSearchViewModel>> Handle(GetProductsListSearchQuery request, CancellationToken cancellationToken)
        {
            var allProducts = await _productRepository.GetProductBySearch(request.textSearch , true);
            return _mapper.Map<List<GetProductsListSearchViewModel>>(allProducts);

        }
    }
}
