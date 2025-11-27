using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.CartCommands.CreateCart
{
    public class CreateCartCommand:IRequest<ServiceResponse>
    {
        public Guid UserId { get; set; }

        public CreateCartCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
