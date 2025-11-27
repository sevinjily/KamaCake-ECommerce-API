using KamaCake.Application.Bases;

namespace KamaCake.Application.Features.Queries.FavoriteQueries.Exceptions
{
    public class NoAnyFavoriteException:BaseException
    {
        public NoAnyFavoriteException() : base("There isn't any favorite product") { }
       
    }
}
