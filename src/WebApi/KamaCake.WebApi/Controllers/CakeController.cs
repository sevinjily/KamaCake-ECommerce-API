using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Features.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KamaCake.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly IMediator mediator;

        public CakeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCake([FromBody] CreateCakeDTO model)
        {
            var command=new CreateCakeCommand(model);
            var result=await mediator.Send(command);
            if (!result.isSuccess) return BadRequest(result.Message);

           return StatusCode((int)result.StatusCode,result.Message);

        }
    }
}
