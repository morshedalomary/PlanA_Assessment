
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanA_Assessment.Application.Features.Category.Queries.GetCategoryDetail;
using PlanA_Assessment.Application.Features.Categorys.Commands.CreateCategory;
using PlanA_Assessment.Application.Features.Categorys.Commands.DeleteCategory;
using PlanA_Assessment.Application.Features.Categorys.Commands.UpdateCategory;
using PlanA_Assessment.Application.Features.Categorys.Queries.GetCategoryDetail;
using PlanA_Assessment.Application.Features.Categorys.Queries.GetCategoryList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanA_Assessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategorys")]
        public async Task<ActionResult<List<GetCategorysListViewModel>>> GetAllCategorys()
        {
            var dtos = await _mediator.Send(new GetCategorysListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<GetCategoryDetailViewModel>> GetCategoryById(Guid id)
        {
            var getEventDetailQuery = new GetCategoryDetailQuery() { CategoryId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost("AddCategory" , Name = "AddCategory")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            Guid id = await _mediator.Send(createCategoryCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateCategory")]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand() { ID = id };
            await _mediator.Send(deleteCategoryCommand);
            return NoContent();
        }

    }
}
