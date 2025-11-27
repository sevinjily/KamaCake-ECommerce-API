using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Interfaces.UnitOfWorks;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;

namespace KamaCake.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IValidator<CreateCategoryDTO> validator;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,IValidator<CreateCategoryDTO> validator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<ServiceResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
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
            try
            {
                var categoryEntity = mapper.Map<Category>(request.Model);
                await unitOfWork.GetWriteRepository<Category>().AddAsync(categoryEntity);

                return new ServiceResponse(
               IsSuccess: true,
               statusCode: System.Net.HttpStatusCode.Created,
               message: "Category uğurla yaradıldı"
           );
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError,
                    message: $"Category yaradılmadı: {ex.Message}"
                );


            }

        }
    }
}
