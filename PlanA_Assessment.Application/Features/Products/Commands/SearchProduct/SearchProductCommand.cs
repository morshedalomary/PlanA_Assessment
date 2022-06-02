using MediatR;
using System;

namespace PlanA_Assessment.Application.Features.Products.Commands.SearchProduct
{
    public class SearchProductCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        public byte[] Image { get; set; }

        public int Number_of_Views { get; set; }


        public string Dietary_flags { get; set; }

        public Guid CategoryId { get; set; }
    }
}
