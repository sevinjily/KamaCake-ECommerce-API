using AutoMapper;
using KamaCake.Application.Features.Commands.FavoriteCommands.Rules;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace KamaCake.Application.Features.Commands.FavoriteCommands.CreateFavorite
{
    public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand, Unit>
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IMapper mapper;
        private readonly ICakeRepository cakeRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly FavoriteRules favoriteRules;

        public CreateFavoriteCommandHandler(IFavoriteRepository favoriteRepository ,IMapper mapper,ICakeRepository cakeRepository,IHttpContextAccessor httpContextAccessor,FavoriteRules favoriteRules)
        {
            this.favoriteRepository = favoriteRepository;
            this.mapper = mapper;
            this.cakeRepository = cakeRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.favoriteRules = favoriteRules;
        }
        public async Task<Unit> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
        {

            //USER LOGIN OLUBMU?
            // User ID-ni context-dən çıxar
            var user = httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException();

            string? userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                throw new UnauthorizedAccessException();

            //CAKE TABLE DA BELE BIR CAKE VARMI?
            Cake? findProduct = await cakeRepository.GetByIdAsync(request.ProductId);
            await favoriteRules.ProductMustBeInDb(findProduct);
           

            //Yeni Favorite obyektini yarat
            var favorite = new Favorite { UserId =Guid.Parse(userIdClaim), ProductId = request.ProductId };

            await favoriteRepository.CreateAsync(favorite);

            return Unit.Value;
        }
    }
}
