using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.AuthCommands.RevokeAll
{
    public class RevokeAllCommand:IRequest<ServiceResponse>
    {
    }
}
