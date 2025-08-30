using KamaCake.Application.Interfaces.Tokens;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        public async Task<ServiceResponseWithData<RefreshTokenCommandResponse>> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var principle=tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email=principle.FindFirstValue(ClaimTypes.Email);

            User? user =await userManager.FindByEmailAsync(email);
            IList<string> roles = await userManager.GetRolesAsync(user);

            if (user.ResfreshTokenExpiryTime <= DateTime.Now)
                return new ServiceResponseWithData<RefreshTokenCommandResponse>
                    (default, false, System.Net.HttpStatusCode.BadRequest,
                    "Qeydiyyat vaxtı bitmişdir! Xahiş edirik təkrar giriş edin!");

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
            string newRefreshToken = tokenService.GenerateRefreshToken();

            user.ResfreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new ServiceResponseWithData<RefreshTokenCommandResponse>
                 (value: new RefreshTokenCommandResponse
                 {
                     AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                     RefreshToken = newRefreshToken
                 },
                 isSuccess:true,
                 statusCode:System.Net.HttpStatusCode.OK
                 );
        }
    }
}
