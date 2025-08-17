using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Wrappers;
using MediatR;

namespace KamaCake.Application.Features.Commands.CreateProduct
{
    public class CreateCakeCommand:IRequest<ServiceResponse<Guid>>
    {
        public CreateCakeDTO Model { get; set; }
        public CreateCakeCommand(CreateCakeDTO model)
        {
            Model = model;
        }
    }
}
