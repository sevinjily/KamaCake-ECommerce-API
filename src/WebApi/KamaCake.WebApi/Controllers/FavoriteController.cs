using KamaCake.Application.Features.Commands.FavoriteCommands.CreateFavorite;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KamaCake.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IMediator mediator;

        public FavoriteController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFavoriteProduct(CreateFavoriteCommand command)
        {
            // İstifadəçi login olub-olmadığını yoxlayırıq
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "Cart yaratmaq üçün əvvəlcə login olun." });
            }

            //var userId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);//Tokenden gelen UserId

            
            var result = await mediator.Send(command);
            return Ok();

            
        }
    }
}
