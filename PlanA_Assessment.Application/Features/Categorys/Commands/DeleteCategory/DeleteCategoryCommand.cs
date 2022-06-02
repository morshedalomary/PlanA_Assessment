using MediatR;
using System;

namespace PlanA_Assessment.Application.Features.Categorys.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid ID { get; set; }
    }

}
