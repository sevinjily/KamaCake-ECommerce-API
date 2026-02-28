using AutoMapper;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Interfaces.Tokens;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace KamaCake.Application.Features.Commands.CartItemCommands
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, ServiceResponse>
    {
        private readonly ICartItemRepository cartItemRepo;
        private readonly ITokenService tokenService;
        private readonly ICakeRepository cakeRepo;
        private readonly ICartRepository cartRepo;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateCartItemCommandHandler(ICartItemRepository cartItemRepo, ITokenService tokenService, ICakeRepository cakeRepo,ICartRepository cartRepo,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            this.cartItemRepo = cartItemRepo;
            this.tokenService = tokenService;
            this.cakeRepo = cakeRepo;
            this.cartRepo = cartRepo;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }
       
        public async Task<ServiceResponse> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {

            //MEHSULUN BAZADA OLUB-OLMADIGINI YOXLASIN
            var findItem=await cakeRepo.GetByIdAsync(request.Model.CakeId);

            if(findItem == null || findItem.IsStock==false) 
                return new ServiceResponse(false,System.Net.HttpStatusCode.NotFound,"Bu məhsul yoxdur və ya tükənib!");

            //ISTIFADECININ SEBETI YOXDURSA SEBET YARATSIN
      
            var user = httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException();

            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                throw new UnauthorizedAccessException();

            //Sebetinin olub-olmadigini yoxlayiriq.
            var existCart = await cartRepo.GetByUserIdAsync(Guid.Parse(userIdClaim));

            //Eger sebeti yoxdursa yaradiriq
            if (existCart==null)
            {

                existCart = new Cart { UserId = Guid.Parse(userIdClaim) };
            await cartRepo.CreateAsync(existCart);
            }

            //Sebetde eyni mehsul varsa sayini artirsin
            var existItem = await cartItemRepo.GetByIdAsync(request.Model.CakeId);

            if(existItem!=null)
            {
                existItem.Quantity += 1;
            }
            //sebeti varsa cartitem i sebete elave edirik
            var cartItemEntity = mapper.Map<CartItem>(request.Model);

            cartItemEntity.CartId = existCart.Id;

            await cartItemRepo.CreateAsync(cartItemEntity);

            return new ServiceResponse(true, System.Net.HttpStatusCode.OK, "Mehsul sebete gonderildi");


        }
    }
}
