using AutoMapper;
using KamaCake.Application.Features.Commands.FavoriteCommands.Rules;
using KamaCake.Application.Interfaces.UnitOfWorks;
using KamaCake.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace KamaCake.Application.Features.Commands.FavoriteCommands.CreateFavorite
{
    public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly FavoriteRules favoriteRules;

        public CreateFavoriteCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor,FavoriteRules favoriteRules)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
            Cake? findProduct = await unitOfWork.GetReadRepository<Cake>().GetAsync(x=>x.Id==request.ProductId);
            await favoriteRules.ProductMustBeInDb(findProduct);
           

            //Yeni Favorite obyektini yarat
            var favorite = new Favorite { UserId =Guid.Parse(userIdClaim), ProductId = request.ProductId };

            await unitOfWork.GetWriteRepository<Favorite>().AddAsync(favorite);

            return Unit.Value;
        }
    }
}
