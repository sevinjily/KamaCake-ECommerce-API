using KamaCake.Application.Features.Commands.CartItemCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KamaCake.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly IMediator mediator;

        public CartItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateCartItem([FromForm]CreateCartItemCommand command)
        {
            // İstifadəçi login olub-olmadığını yoxlayırıq
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "CartItem yaratmaq üçün əvvəlcə login olun." });
            }

            //var userId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);//Tokenden gelen UserId


            //command i nezerden kecirersen yene de

            var result = await mediator.Send(command);

            if (!result.isSuccess)
                return BadRequest(result.Message);

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}
