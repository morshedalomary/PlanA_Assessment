using MediatR;
using PlanA_Assessment.Application.Features.Category.Queries.GetCategoryDetail;
using System;

namespace PlanA_Assessment.Application.Features.Categorys.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery : IRequest<GetCategoryDetailViewModel>
    {
        public Guid CategoryId { get; set; }
    }
}
