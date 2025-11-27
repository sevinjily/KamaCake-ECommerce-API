using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KamaCake.Application.Features.Commands.AuthCommands.Revoke
{
    public class RevokeCommandHandler : IRequestHandler<RevokeCommand, ServiceResponse>
    {
        private readonly UserManager<User> userManager;

        public RevokeCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<ServiceResponse> Handle(RevokeCommand request, CancellationToken cancellationToken)
        {
            User user= await userManager.FindByEmailAsync(request.Email);
            if (user is null) 
                return new ServiceResponse(false,System.Net.HttpStatusCode.NotFound);

            user.ResfreshToken = null;
            await userManager.UpdateAsync(user);
            return new ServiceResponse(true,System.Net.HttpStatusCode.OK);
        }
    }
}
