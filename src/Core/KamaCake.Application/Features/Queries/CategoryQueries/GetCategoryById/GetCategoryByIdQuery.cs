using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Queries.CategoryQueries.GetCategoryById
{
    public class GetCategoryByIdQuery:IRequest<ServiceResponseWithData<GetCategoryByIdDTO>>
    {
        public Guid Id { get; set; }
        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
