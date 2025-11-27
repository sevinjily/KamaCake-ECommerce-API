using KamaCake.Application.Features.Queries.FavoriteQueries.Rules;
using KamaCake.Application.Interfaces.UnitOfWorks;
using KamaCake.Domain.Entities;
using MediatR;

namespace KamaCake.Application.Features.Queries.FavoriteQueries.GetAllFavorites
{
    public class GetAllFavoritesQueryHandler : IRequestHandler<GetAllFavoritesQueryRequest, IList<GetAllFavoritesQueryResponse>>
    {
        private readonly FavoriteQueryRules favoriteRules;
        private readonly IUnitOfWork unitOfWork;

        public GetAllFavoritesQueryHandler(FavoriteQueryRules favoriteRules,IUnitOfWork unitOfWork)
        {
            this.favoriteRules = favoriteRules;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllFavoritesQueryResponse>> Handle(GetAllFavoritesQueryRequest request, CancellationToken cancellationToken)
        {

            IList<Favorite> findFavorites = await unitOfWork.GetReadRepository<Favorite>().GetAllAsync();
            await favoriteRules.NoAnyFavorite(findFavorites);

         return findFavorites
     .Select(f => new GetAllFavoritesQueryResponse
     {
         Id = f.Id,
         ProductName = f.Product.Name
     })
     .ToList();
        }
    }
}
