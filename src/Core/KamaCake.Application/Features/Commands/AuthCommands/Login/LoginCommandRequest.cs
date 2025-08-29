using KamaCake.Application.DTOs.AuthDTOs;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.AuthCommands.Login
{
    public class LoginCommandRequest:IRequest<ServiceResponseWithData<LoginCommandResponse>>
    {
        public LoginDTO Model { get; set; }
        public LoginCommandRequest(LoginDTO model)
        {
            Model = model;
        }
    }
}
