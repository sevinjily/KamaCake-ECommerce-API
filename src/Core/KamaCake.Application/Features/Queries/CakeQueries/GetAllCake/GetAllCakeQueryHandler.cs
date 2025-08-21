using AutoMapper;
using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Queries.CakeQueries.GetAllCake
{
    public class GetAllCakeQueryHandler : IRequestHandler<GetAllCakeQuery, ServiceResponseWithData<List<GetCakeDTO>>>
    {
        private readonly ICakeRepository repository;
        private readonly IMapper mapper;

        public GetAllCakeQueryHandler(ICakeRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ServiceResponseWithData<List<GetCakeDTO>>> Handle(GetAllCakeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cakes = await repository.GetAllAsync();
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
