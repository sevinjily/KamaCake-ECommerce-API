using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Interfaces.RedisCahce;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Queries.CakeQueries.GetAllCake
{
    public class GetAllCakeQuery : IRequest<ServiceResponseWithData<List<GetCakeDTO>>>, ICacheableQuery
    {
        public string CacheKey => "GetAllCakes";

        public double CacheTime => 60;
    }
}
