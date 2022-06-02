
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlanA_Assessment.Application.Features.Products.Commands.CreateProduct;
using PlanA_Assessment.Application.Features.Products.Commands.DeleteProduct;

using PlanA_Assessment.Application.Features.Products.Commands.UpdateProduct;
using PlanA_Assessment.Application.Features.Products.Queries.GetProductDetail;
using PlanA_Assessment.Application.Features.Products.Queries.GetProductList;
using PlanA_Assessment.Application.Features.Products.Queries.GetProductListBySearch;
using PlanA_Assessment.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlanA_Assessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllProducts")]
        public async Task<ActionResult<List<GetProductsListViewModel>>> GetAllProducts()
        {
            var dtos = await _mediator.Send(new GetProductsListQuery());
            return Ok(dtos);
        }
        [HttpGet("search/{search?}", Name = "GetSearchProducts")]
        public async Task<ActionResult<List<GetProductsListSearchViewModel>>> GetSearchProducts(string search)
        {
            var dtos = await _mediator.Send(new GetProductsListSearchQuery() { textSearch= search });
            return Ok(dtos);
        }
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<GetProductDetailViewModel>> GetProductById(Guid id)
        {
            var getEventDetailQuery = new GetProductDetailQuery() { ProductId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost("AddProduct", Name = "AddProduct")]
        [Consumes("multipart/form-data")]

        public async Task<HttpResponseMessage> AddProduct([FromForm] ProductCommand createProductCommand)
        {
            CreateProductCommand product = new CreateProductCommand();
            product.Description = createProductCommand.Description;
            product.Title = createProductCommand.Title;

            product.Description = createProductCommand.Description;

            product.Price = createProductCommand.Price;

            product.Dietary_flags = createProductCommand.Dietary_flags;
            
            product.CategoryId = createProductCommand.CategoryId;




            if (createProductCommand.Image != null)
            {
                if (createProductCommand.Image.Length > 0 )
                {
                    using (var ms = new MemoryStream())
                    {
                        createProductCommand.Image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        product.Image = fileBytes;


                        Guid id = await _mediator.Send(product);
                        return new HttpResponseMessage(HttpStatusCode.OK);


                    }

                }
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);


        }

        [HttpPut(Name = "UpdateProduct")]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> Update([FromForm] ProductUpdateCommand updateProductCommand)
        {
            UpdateProductCommand product = new UpdateProductCommand();
            product.Description = updateProductCommand.Description;
            product.Title = updateProductCommand.Title;

            product.Description = updateProductCommand.Description;

            product.Price = updateProductCommand.Price;

            product.Dietary_flags = updateProductCommand.Dietary_flags;

            product.CategoryID = updateProductCommand.CategoryID;
            product.ID = updateProductCommand.ID;




            if (updateProductCommand.Image != null) { 
                if (updateProductCommand.Image.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        updateProductCommand.Image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        product.Image = fileBytes;


                        await _mediator.Send(product);
                        return new HttpResponseMessage(HttpStatusCode.OK);


                    }

                }
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteProductCommand = new DeleteProductCommand() { ProductId = id };
            await _mediator.Send(deleteProductCommand);
            return NoContent();
        }

    }
}
