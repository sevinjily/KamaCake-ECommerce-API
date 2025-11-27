using KamaCake.Domain.Entities;

namespace KamaCake.Application.Features.Queries.FavoriteQueries.GetAllFavorites
{
    public class GetAllFavoritesQueryResponse
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
    }
}
