using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.CakeCommands.CreateCake
{
    public class CreateCakeCommand:IRequest<ServiceResponse>
    {
        public CreateCakeDTO Model { get; set; }
        public CreateCakeCommand(CreateCakeDTO model)
        {
            Model = model;
        }
    }
}
