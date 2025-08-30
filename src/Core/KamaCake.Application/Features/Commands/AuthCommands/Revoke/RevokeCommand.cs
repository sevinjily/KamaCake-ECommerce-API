using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.AuthCommands.Revoke
{
    public class RevokeCommand:IRequest<ServiceResponse>
    {
        public string Email { get; set; }
    }
}
