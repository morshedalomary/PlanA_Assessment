using AutoMapper;

using MediatR;
using PlanA_Assessment.Application.Contracts;
using PlanA_Assessment.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlanA_Assessment.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductsRepository _ProductRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductsRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Product is not valid");
            }

            product = await _ProductRepository.AddAsync(product);

            return product.ID;
        }
    }
}
