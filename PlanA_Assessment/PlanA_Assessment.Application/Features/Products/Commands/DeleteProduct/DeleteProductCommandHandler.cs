
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PlanA_Assessment.Application.Contracts;

namespace PlanA_Assessment.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductsRepository _productRepository;
        public DeleteProductCommandHandler(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var post = await _productRepository.GetByIdAsync(request.ProductId);

            await _productRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }

}
