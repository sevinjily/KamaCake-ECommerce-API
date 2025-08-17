using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Wrappers;

namespace KamaCake.Application.Interfaces.Services.CakeService
{
    public interface ICakeService
    {
        public Task<ServiceResponse<Guid>> CreateCakeAsync(CreateCakeDTO model);
    }
}
 