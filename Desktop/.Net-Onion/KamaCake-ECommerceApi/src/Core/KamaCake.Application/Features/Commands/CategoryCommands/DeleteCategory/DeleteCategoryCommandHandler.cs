using KamaCake.Application.Interfaces.UnitOfWorks;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;

namespace KamaCake.Application.Features.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ServiceResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? findCategory = await unitOfWork.GetReadRepository<Category>().GetAsync(x=>x.Id==request.Id);
            if (findCategory == null)
                return new ServiceResponse(false, System.Net.HttpStatusCode.NotFound, "Belə kateqoriya tapılmadı");

            try
            {
                await unitOfWork.GetWriteRepository<Category>().SoftDeleteAsync(findCategory);


                return new ServiceResponse(
               IsSuccess: true,
               statusCode: System.Net.HttpStatusCode.OK,
               message: "Category uğurla silindi"
           );
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError,
                    message: $"Category silinə bilmədi: {ex.Message}"
                );
            }


        }

    }
}
