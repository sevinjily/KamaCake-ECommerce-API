using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Interfaces.UnitOfWorks;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;

namespace KamaCake.Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ServiceResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IValidator<UpdateCategoryDTO> validator;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,IValidator<UpdateCategoryDTO> validator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<ServiceResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(request.Model, cancellationToken);
            Category? findCategory =await unitOfWork.GetReadRepository<Category>().GetAsync(x=>x.Id==request.Id);

            if (findCategory == null)
                return new ServiceResponse(false, System.Net.HttpStatusCode.NotFound, "Belə kateqoriya tapılmadı");
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new ServiceResponse(false,System.Net.HttpStatusCode.BadRequest,errors);
                   
            }

            
            try
            {
                mapper.Map(request.Model, findCategory);
                 await unitOfWork.GetWriteRepository<Category>().UpdateAsync(findCategory);


                return new ServiceResponse(
               IsSuccess: true,
               statusCode: System.Net.HttpStatusCode.OK,
               message: "Category uğurla yeniləndi"
           );
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError,
                    message: $"Category yenilənmədi: {ex.Message}"
                );


            }
        }
    }
}
