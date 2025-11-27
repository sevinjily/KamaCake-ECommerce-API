using MediatR;

namespace KamaCake.Application.Features.Queries.FavoriteQueries.GetAllFavorites
{
    public class GetAllFavoritesQueryRequest:IRequest<IList<GetAllFavoritesQueryResponse>>
    {
    }
}
