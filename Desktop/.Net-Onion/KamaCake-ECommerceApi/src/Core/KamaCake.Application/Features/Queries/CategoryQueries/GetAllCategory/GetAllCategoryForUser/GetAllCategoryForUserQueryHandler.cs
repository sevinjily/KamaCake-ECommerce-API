using AutoMapper;
using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Queries.CategoryQueries.GetAllCategory.GetAllCategoryForUser
{
    public class GetAllCategoryForUserQueryHandler : IRequestHandler<GetAllCategoryForUserQuery, ServiceResponseWithData<List<GetAllCategoryForUserDTO>>>
    {
        private readonly ICategoryRepository repository;
        private readonly IMapper mapper;

        public GetAllCategoryForUserQueryHandler(ICategoryRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ServiceResponseWithData<List<GetAllCategoryForUserDTO>>> Handle(GetAllCategoryForUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await repository.GetAllAsync();
                var viewModel = mapper.Map<List<GetAllCategoryForUserDTO>>(categories);

                return new ServiceResponseWithData<List<GetAllCategoryForUserDTO>>(
                    value: viewModel,
               isSuccess: true,
               statusCode: System.Net.HttpStatusCode.OK
             
           );
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponseWithData<List<GetAllCategoryForUserDTO>>(
                    value:default,
                    isSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError
                );


            }
         

        }
    }
}
