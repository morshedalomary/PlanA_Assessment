using MediatR;
using System;

namespace PlanA_Assessment.Application.Features.Categorys.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public Guid ID { get; set; }
    }
}
