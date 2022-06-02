using MediatR;
using System;

namespace PlanA_Assessment.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        public byte[] Image { get; set; }

        public int Number_of_Views { get; set; }


        public string Dietary_flags { get; set; }
        public Guid CategoryID { get; set; }

    }
}
