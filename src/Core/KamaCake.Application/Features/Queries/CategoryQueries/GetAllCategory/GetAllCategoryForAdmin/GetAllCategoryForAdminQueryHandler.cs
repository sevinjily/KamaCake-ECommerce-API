using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;

namespace KamaCake.Application.Features.Queries.CategoryQueries.GetAllCategory.GetAllCategoryForAdmin
{
    public class GetAllCategoryForAdminQueryHandler : IRequestHandler<GetAllCategoryForAdminQuery, ServiceResponseWithData<List<Category>>>
    {
        private readonly ICategoryRepository repository;

        public GetAllCategoryForAdminQueryHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ServiceResponseWithData<List<Category>>> Handle(GetAllCategoryForAdminQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var categories = await repository.GetAllAsync();

                return new ServiceResponseWithData<List<Category>>(
              value: categories,
              isSuccess: true,
              statusCode: System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex) 
            {
                return new ServiceResponseWithData<List<Category>>(
                   value: default,
                   isSuccess: false,
                   statusCode: System.Net.HttpStatusCode.InternalServerError
               );

            }
        }
    }
}
