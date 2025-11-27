using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KamaCake.Application.Features.Commands.AuthCommands.RevokeAll
{
    public class RevokeAllCommandHandler : IRequestHandler<RevokeAllCommand,ServiceResponse>
    {
        private readonly UserManager<User> userManager;

        public RevokeAllCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ServiceResponse> Handle(RevokeAllCommand request, CancellationToken cancellationToken)
        {
            List<User> users =  await userManager.Users.ToListAsync(cancellationToken);
            foreach (User user in users)
            {
                user.ResfreshToken = null;
                await userManager.UpdateAsync(user);
            }
            return new ServiceResponse(true,System.Net.HttpStatusCode.OK);
        }
    }
}
