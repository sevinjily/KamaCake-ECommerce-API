using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest<ServiceResponse>
    {
        public Guid Id { get; set; }
        public UpdateCategoryDTO Model { get; set; }
        public UpdateCategoryCommand(Guid id,UpdateCategoryDTO model)
        {
            Id = id;
            Model = model;
            
        }
    }
}
