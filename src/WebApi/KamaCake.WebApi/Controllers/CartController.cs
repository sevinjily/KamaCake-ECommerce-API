using KamaCake.Application.Features.Commands.CartCommands.CreateCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KamaCake.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IMediator mediator;

        public CartController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("[action]")]
       
        public async Task<IActionResult> CreateCart()
        {

            // İstifadəçi login olub-olmadığını yoxlayırıq
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "Cart yaratmaq üçün əvvəlcə login olun." });
            }

            var userId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);//Tokenden gelen UserId

            var command=new CreateCartCommand(userId);
            var result=await mediator.Send(command);

            if(!result.isSuccess)
                return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode, result.Message);

        }

    }
}
