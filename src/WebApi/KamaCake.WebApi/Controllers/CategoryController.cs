using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Features.Commands.CreateCategory;
using KamaCake.Application.Features.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO model)
        {
            var command = new CreateCategoryCommand(model);
            var result = await mediator.Send(command);
            if (!result.isSuccess) return BadRequest(result.Message);
                
            return StatusCode((int)result.StatusCode, result.Message);

        }
    }
}
