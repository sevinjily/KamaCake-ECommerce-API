using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Features.Commands.CategoryCommands.CreateCategory;
using KamaCake.Application.Features.Commands.CategoryCommands.UpdateCategory;
using MediatR;
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
    }
}
