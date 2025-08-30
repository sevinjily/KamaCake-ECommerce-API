using KamaCake.Application.DTOs.AuthDTOs;
using KamaCake.Application.Features.Commands.AuthCommands.Login;
using KamaCake.Application.Features.Commands.AuthCommands.RefreshToken;
using KamaCake.Application.Features.Commands.AuthCommands.Register;
using KamaCake.Application.Features.Commands.CakeCommands.CreateCake;
using KamaCake.Application.Features.Commands.CakeCommands.DeleteCake;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KamaCake.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterCommand model )
        {
            var result = await mediator.Send(model);
            if (!result.isSuccess) return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode, result.Message);

        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginCommandRequest model)
        {
            var response = await mediator.Send(model);
            if (!response.isSuccess) return BadRequest(response.Message);

            return StatusCode((int)response.StatusCode, response);

        }
        [HttpPost]
        public async Task<IActionResult> ResfreshToken(RefreshTokenCommandRequest model)
        {
            var response = await mediator.Send(model);
            if (!response.isSuccess) return BadRequest(response.Message);

            return StatusCode((int)response.StatusCode, response);

        }
    }
}
