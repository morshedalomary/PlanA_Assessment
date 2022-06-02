using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PlanA_Assessment.Application.Contracts;

namespace PlanA_Assessment.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, GetProductDetailViewModel>
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductDetailViewModel> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var Product = await _productRepository.GetProductByIdAsync(request.ProductId, true);

            return _mapper.Map<GetProductDetailViewModel>(Product);
        }
    }
}
