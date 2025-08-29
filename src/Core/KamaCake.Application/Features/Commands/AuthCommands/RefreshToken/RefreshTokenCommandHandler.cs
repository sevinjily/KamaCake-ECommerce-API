using KamaCake.Application.Interfaces.Tokens;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KamaCake.Application.Features.Commands.AuthCommands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, ServiceResponseWithData<RefreshTokenCommandResponse>>
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;

        public RefreshTokenCommandHandler(UserManager<User> userManager,ITokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }
        public Task<ServiceResponseWithData<RefreshTokenCommandResponse>> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var principle=tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        }
    }
}
