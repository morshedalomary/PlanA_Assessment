using System;

namespace PlanA_Assessment.Application.Features.Products.Queries.GetProductList
{
    public class GetProductsListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public CategoryDto Category { get; set; }
    }
}
