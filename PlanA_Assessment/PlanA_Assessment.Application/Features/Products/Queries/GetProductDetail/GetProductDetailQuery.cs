using MediatR;
using System;

namespace PlanA_Assessment.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<GetProductDetailViewModel>
    {
        public Guid ProductId { get; set; }
    }
}
