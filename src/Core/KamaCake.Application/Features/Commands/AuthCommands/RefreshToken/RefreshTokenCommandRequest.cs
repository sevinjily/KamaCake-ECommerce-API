using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.AuthCommands.RefreshToken
{
    public class RefreshTokenCommandRequest:IRequest<ServiceResponseWithData<RefreshTokenCommandResponse>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
