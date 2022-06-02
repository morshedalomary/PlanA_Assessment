using AutoMapper;
using MediatR;
using PlanA_Assessment.Application.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlanA_Assessment.Application.Features.Products.Queries.GetProductList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<GetProductsListViewModel>>
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<GetProductsListViewModel>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = await _productRepository.GetAllProductsAsync(true);
            return _mapper.Map<List<GetProductsListViewModel>>(allProducts);
        }
    }
}
