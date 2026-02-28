using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ServiceResponse>
    {
        private readonly ICategoryRepository repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
            
        }

        public async Task<ServiceResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var findCategory = await repository.GetByIdAsync(request.Id);
            if (findCategory == null)
                return new ServiceResponse(false, System.Net.HttpStatusCode.NotFound, "Belə kateqoriya tapılmadı");

            try
            {
                await repository.DeleteAsync(request.Id);


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
