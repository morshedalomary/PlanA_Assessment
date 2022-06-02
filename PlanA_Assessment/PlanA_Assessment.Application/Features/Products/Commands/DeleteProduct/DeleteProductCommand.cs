using MediatR;
using System;

namespace PlanA_Assessment.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
    }

}
