using AutoMapper;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;

namespace KamaCake.Application.Features.Commands.CartCommands.CreateCart
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, ServiceResponse>
    {
        private readonly ICartRepository repo;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepo;

        public CreateCartCommandHandler(ICartRepository repo,IMapper mapper,IUserRepository userRepo)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.userRepo = userRepo;
        }
        public async Task<ServiceResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {

            try
            {
            var findUser=await userRepo.GetByIdAsync(request.UserId);
            if (findUser == null)
                return new ServiceResponse(false, System.Net.HttpStatusCode.NotFound, "Belə istifadəçi yoxdur!");


                var findAlreadyExistCart = await repo.GetByUserIdAsync(request.UserId);
                if (findAlreadyExistCart != null) 
                    return new ServiceResponse(false,System.Net.HttpStatusCode.BadRequest,"Bu istifadəçinin artıq səbəti var!");


            var cartEntity = mapper.Map<Cart>(request);
               // var cartEntity = new Cart { UserId = request.UserId };
                 await repo.CreateAsync(cartEntity);

            return new ServiceResponse(
             IsSuccess: true,
             statusCode: System.Net.HttpStatusCode.Created,
             message: "Cart uğurla yaradıldı!"
         );
            }
            catch (Exception ex)
            {
                return new ServiceResponse(
                 IsSuccess: false,
                 statusCode: System.Net.HttpStatusCode.InternalServerError,
                 message: $"Cart yaradılmadı!: {ex.Message}"
             );
            }
        }
    }
}
