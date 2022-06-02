using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace PlanA_Assessment.Application.Features.Products.Commands.UpdateProduct
{
    public class ProductUpdateCommand 
    {
        public IFormFile Image { get; set; }

        public  string Title { get; set; }
        public  string Description { get; set; }

        public double Price { get; set; }

        public int Number_of_Views { get; set; }


        public string Dietary_flags { get; set; }

        public Guid CategoryID { get; set; }

        public Guid ID { get; set; }


    }


    }

