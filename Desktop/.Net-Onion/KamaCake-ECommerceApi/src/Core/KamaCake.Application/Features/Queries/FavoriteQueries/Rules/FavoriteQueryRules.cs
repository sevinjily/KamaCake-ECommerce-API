using KamaCake.Application.Bases;
using KamaCake.Application.Features.Queries.FavoriteQueries.Exceptions;
using KamaCake.Domain.Entities;

namespace KamaCake.Application.Features.Queries.FavoriteQueries.Rules
{
    public class FavoriteQueryRules:BaseRule
    {
        public Task NoAnyFavorite(IList<Favorite?> favorite)
        {
            if (favorite is null) throw new NoAnyFavoriteException();
            return Task.CompletedTask;
        }
    }
}
