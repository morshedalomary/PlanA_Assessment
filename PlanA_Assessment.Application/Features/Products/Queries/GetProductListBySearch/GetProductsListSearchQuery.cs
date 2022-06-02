using MediatR;
using System.Collections.Generic;

namespace PlanA_Assessment.Application.Features.Products.Queries.GetProductListBySearch
{
    public class GetProductsListSearchQuery : IRequest<List<GetProductsListSearchViewModel>>
    {
        public string textSearch { get; set; }

    }
}
