using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommand:IRequest<ServiceResponse>
    {

        public CreateCategoryDTO Model { get; set; }
        public CreateCategoryCommand(CreateCategoryDTO model)
        {
            Model = model;
        }
    }
}
