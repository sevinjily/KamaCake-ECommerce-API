using MediatR;

namespace KamaCake.Application.Features.Commands.FavoriteCommands.CreateFavorite
{
    public class CreateFavoriteCommand:IRequest<Unit>
    {
        public Guid ProductId { get; set; }
    }
}
