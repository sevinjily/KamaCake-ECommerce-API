using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Features.Commands.CakeCommands.CreateCake;
using KamaCake.Application.Features.Commands.CakeCommands.DeleteCake;
using KamaCake.Application.Features.Commands.CakeCommands.UpdateCake;
using KamaCake.Application.Features.Queries.CakeQueries.GetAllCake;
using KamaCake.Application.Features.Queries.CakeQueries.GetCakeById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPut("[action]")] 
        public async Task<IActionResult> UpdateCake([FromQuery] Guid id,UpdateCakeDTO model)
        {
            var command=new UpdateCakeCommand(id,model);
            var result=await mediator.Send(command);
            if (!result.isSuccess)
                return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode, result.Message);

        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCake([FromQuery] Guid id)
        {
            var command = new DeleteCakeCommand(id);
            var result = await mediator.Send(command);
            if (!result.isSuccess)
                return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode, result.Message);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCakeById([FromQuery]Guid id)
        {
            var query = new GetCakeByIdQuery(id);
            var result = await mediator.Send(query);
            if (!result.isSuccess)
                return BadRequest(result.Message);

            return Ok(result);

        }
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> GetAllCakes()
        {
            var query = new GetAllCakeQuery();
            var result = await mediator.Send(query);
            if (!result.isSuccess)
                return BadRequest(result.Message);

            return Ok(result);

        }
    }
}
