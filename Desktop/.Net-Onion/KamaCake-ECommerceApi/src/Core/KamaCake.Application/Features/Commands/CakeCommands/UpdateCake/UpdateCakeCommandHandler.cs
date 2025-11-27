using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.CakeCommands.UpdateCake
{
    public class UpdateCakeCommandHandler : IRequestHandler<UpdateCakeCommand, ServiceResponse>
    {
        private readonly ICakeRepository repository;
        private readonly IMapper mapper;
        private readonly IValidator<UpdateCakeDTO> validator;
        private readonly ICategoryRepository categoryRepo;

        public UpdateCakeCommandHandler(ICakeRepository repository,IMapper mapper,IValidator<UpdateCakeDTO> validator,ICategoryRepository categoryRepo)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
            this.categoryRepo = categoryRepo;
        }
        public async Task<ServiceResponse> Handle(UpdateCakeCommand request, CancellationToken cancellationToken)
        {
            var findCake=await repository.GetByIdAsync(request.Id);
            ValidationResult validationResult=await validator.ValidateAsync(request.Model, cancellationToken);
            var findCategory = await categoryRepo.GetByIdAsync(request.Model.CategoryId);


            if (findCake == null) 
                return new ServiceResponse(false, System.Net.HttpStatusCode.NotFound, "Belə cake tapılmadı");

            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new ServiceResponse(false, System.Net.HttpStatusCode.BadRequest, errors);

            }
            if (findCategory == null)
                return new ServiceResponse(
                        IsSuccess: false,
                       statusCode: System.Net.HttpStatusCode.BadRequest,
                       message: "Belə bir category yoxdur!"
                       );
            try
            {
                mapper.Map(request.Model, findCake);
                await repository.UpdateAsync(request.Id, findCake);


                return new ServiceResponse(
               IsSuccess: true,
               statusCode: System.Net.HttpStatusCode.OK,
               message: "Cake uğurla yeniləndi"
           );
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError,
                    message: $"Cake yenilənmədi: {ex.Message}"
                );


            }
           
        }
    }
}
