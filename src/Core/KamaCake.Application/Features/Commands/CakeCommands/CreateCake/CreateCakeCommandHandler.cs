using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;

namespace KamaCake.Application.Features.Commands.CakeCommands.CreateCake
{
    public class CreateCakeCommandHandler : IRequestHandler<CreateCakeCommand, ServiceResponse>
    {
        private readonly ICakeRepository repository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateCakeDTO> validator;
        private readonly ICategoryRepository categoryrepo;

        public CreateCakeCommandHandler(ICakeRepository repository, IMapper mapper, IValidator<CreateCakeDTO> validator,ICategoryRepository categoryrepo)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
            this.categoryrepo = categoryrepo;
        }
        public async Task<ServiceResponse> Handle(CreateCakeCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(request.Model, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.BadRequest,
                    message: errors
                );
            }
            //Ikinci defe eyni adda cake yaradilmasin
            if (await repository.ExistsByNameAsync(request.Model.Name))
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.BadRequest,
                    message: "Bu adda cake artıq mövcuddur!"
                    );
           
            var findCategory =await categoryrepo.GetByIdAsync(request.Model.CategoryId);
            if(findCategory == null)
            return new ServiceResponse(
                    IsSuccess: false,
                   statusCode: System.Net.HttpStatusCode.BadRequest,
                   message: "Belə bir category yoxdur!"
                   );
            
            try
            {
                var cakeEntity = mapper.Map<Cake>(request.Model);
                await repository.CreateAsync(cakeEntity);

                return new ServiceResponse(
               IsSuccess: true,
               statusCode: System.Net.HttpStatusCode.Created,
               message: "Cake uğurla yaradıldı"
           );
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError,
                    message: $"Cake yaradılmadı: {ex.Message}"
                );


            }

            

    }
    }
}
