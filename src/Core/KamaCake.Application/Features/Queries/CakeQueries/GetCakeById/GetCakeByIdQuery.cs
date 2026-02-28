using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Interfaces.RedisCahce;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Queries.CakeQueries.GetCakeById
{
    public class GetCakeByIdQuery:IRequest<ServiceResponseWithData<GetCakeDTO>>, ICacheableQuery
    {
        
        public Guid Id { get; set; }

        public string CacheKey => "GetCakeById";

        public double CacheTime => 60;

        public GetCakeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
