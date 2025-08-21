using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Queries.CakeQueries.GetCakeById
{
    public class GetCakeByIdQuery:IRequest<ServiceResponseWithData<GetCakeByIdDTO>>
    {
        public Guid Id { get; set; }
        public GetCakeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
