using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Features.Commands.CategoryCommands.CreateCategory;
using KamaCake.Application.Features.Commands.CategoryCommands.DeleteCategory;
using KamaCake.Application.Features.Commands.CategoryCommands.UpdateCategory;
using KamaCake.Application.Features.Queries.CategoryQueries.GetAllCategory.GetAllCategoryForAdmin;
using KamaCake.Application.Features.Queries.CategoryQueries.GetAllCategory.GetAllCategoryForUser;
using KamaCake.Application.Features.Queries.CategoryQueries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KamaCake.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO model)
        {
            var command = new CreateCategoryCommand(model);
            var result = await mediator.Send(command);
            if (!result.isSuccess) return BadRequest(result.Message);
                
            return StatusCode((int)result.StatusCode, result.Message);

        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory([FromQuery] Guid id, [FromBody] UpdateCategoryDTO model)
        {
            var command= new UpdateCategoryCommand(id,model); 
            var result = await mediator.Send(command);

            if (!result.isSuccess) return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode, result.Message);

        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCategory([FromQuery] Guid id)
        {
            var command=new DeleteCategoryCommand(id);
            var result= await mediator.Send(command);
            if (!result.isSuccess) return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode, result.Message);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategoryForUser()
        {
            var query=new GetAllCategoryForUserQuery();
            var result=await mediator.Send(query);

            if (!result.isSuccess) return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode, result);

        }
        [HttpGet("[action]")]
        [Authorize]
        
        public async Task<IActionResult> GetAllCategoryForAdmin()
        {
            var query = new GetAllCategoryForAdminQuery();
            var result = await mediator.Send(query);

            if (!result.isSuccess) return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode, result);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryById([FromQuery]Guid id)
        {
            var query=new GetCategoryByIdQuery(id);
            var result = await mediator.Send(query);
            if (!result.isSuccess) return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode,result);

        }

    }
}
