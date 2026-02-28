using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.CakeCommands.UpdateCake
{
    public class UpdateCakeCommand:IRequest<ServiceResponse>
    {
        public Guid Id { get; set; }
        public UpdateCakeDTO Model { get; set; }
        public UpdateCakeCommand(Guid id, UpdateCakeDTO model)
        {
            Id = id;
            Model = model;

        }
    }
}
