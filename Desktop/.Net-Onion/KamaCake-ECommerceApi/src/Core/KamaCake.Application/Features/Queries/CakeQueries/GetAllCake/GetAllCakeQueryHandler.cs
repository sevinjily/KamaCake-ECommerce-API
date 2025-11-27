using AutoMapper;
using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Interfaces.UnitOfWorks;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;

namespace KamaCake.Application.Features.Queries.CakeQueries.GetAllCake
{
    public class GetAllCakeQueryHandler : IRequestHandler<GetAllCakeQuery, ServiceResponseWithData<List<GetCakeDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllCakeQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ServiceResponseWithData<List<GetCakeDTO>>> Handle(GetAllCakeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cakes = await unitOfWork.GetReadRepository<Cake>().GetAllAsync();
                var viewModel = mapper.Map<List<GetCakeDTO>>(cakes);

                return new ServiceResponseWithData<List<GetCakeDTO>>(
                    value: viewModel,
                    isSuccess: true,
                    statusCode: System.Net.HttpStatusCode.OK
                    );

            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponseWithData<List<GetCakeDTO>>(
                    value: default,
                    isSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError
                );


            }
        }
    }
}
