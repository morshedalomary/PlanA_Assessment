using PlanA_Assessment.Application.Features.Products.Queries.GetProductList;

using System;

namespace PlanA_Assessment.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public CategoryDto Category { get; set; }
    }
}
