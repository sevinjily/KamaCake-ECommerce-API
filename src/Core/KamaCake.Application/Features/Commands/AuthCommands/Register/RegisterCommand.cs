using KamaCake.Application.DTOs.AuthDTOs;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.AuthCommands.Register
{
    public class RegisterCommand:IRequest<ServiceResponse>
    {
        public RegisterDTO Model { get; set; }
        public RegisterCommand(RegisterDTO model)
        {
            Model = model;
        }

    }
}   
