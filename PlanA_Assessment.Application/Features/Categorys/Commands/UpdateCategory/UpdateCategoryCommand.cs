using MediatR;
using System;

namespace PlanA_Assessment.Application.Features.Categorys.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {

        public string Name { get; set; }
        public Guid ID { get; set; }


    }
}
