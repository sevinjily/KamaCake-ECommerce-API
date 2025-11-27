using KamaCake.Application.Features.Commands.FavoriteCommands.CreateFavorite;
using KamaCake.Application.Features.Queries.CakeQueries.GetAllCake;
using KamaCake.Application.Features.Queries.FavoriteQueries.GetAllFavorites;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KamaCake.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public async Task<IActionResult> GetAllFavorites()
        {
            var query = new GetAllFavoritesQueryRequest();
            Unit result = await mediator.Send(query);
            return Ok(result);


        }
    }
}
