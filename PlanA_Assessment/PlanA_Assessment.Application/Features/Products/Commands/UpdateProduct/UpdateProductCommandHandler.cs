using AutoMapper;

using MediatR;
using PlanA_Assessment.Application.Contracts;
using PlanA_Assessment.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace PlanA_Assessment.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
