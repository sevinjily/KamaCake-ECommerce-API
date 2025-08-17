using FluentValidation;
using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Interfaces.Services.CakeService;
using KamaCake.Application.Wrappers;

namespace KamaCake.Persistence.Services
{
    public class CakeService : ICakeService
    {
        private readonly ICakeRepository repository;
        private readonly IValidator<CreateCakeDTO> validator;

        public CakeService(ICakeRepository repository,IValidator<CreateCakeDTO> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }
        public async Task<ServiceResponse<Guid>> CreateCakeAsync(CreateCakeDTO model)
        {
            var validationResult=await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                // Validation səhvlərini birləşdirib qaytarırıq
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new ServiceResponse<Guid>
                {
                    Value = Guid.Empty,
                    // burada əlavə olaraq mesaj və ya status sahəsi varsa onu istifadə et
                    // Məsələn: Message = errors
                };
            }
           await repository.CreateAsync(model);

                
        }
    }
}
