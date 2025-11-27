using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;

namespace KamaCake.Application.Features.Queries.CategoryQueries.GetAllCategory.GetAllCategoryForAdmin
{
    public class GetAllCategoryForAdminQuery:IRequest<ServiceResponseWithData<List<Category>>>
    {
    }
}
