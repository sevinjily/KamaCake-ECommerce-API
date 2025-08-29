using AutoMapper;
using KamaCake.Application.Interfaces.Tokens;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace KamaCake.Application.Features.Commands.AuthCommands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, ServiceResponseWithData<LoginCommandResponse>>
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;

        public LoginCommandHandler(IMapper mapper,UserManager<User> userManager,ITokenService tokenService,IConfiguration configuration)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }
     public async Task<ServiceResponseWithData<LoginCommandResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Model.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Model.Password);
            if (user is null || !checkPassword)
            
                return new ServiceResponseWithData<LoginCommandResponse>
                    (value:default,
                    false,
                    statusCode: System.Net.HttpStatusCode.Unauthorized,
                    message: "Email və ya parol səhvdir.");

            var roles=await userManager.GetRolesAsync(user);

            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();
            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.ResfreshToken = refreshToken;
            user.ResfreshTokenExpiryTime=DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token=new JwtSecurityTokenHandler().WriteToken(token);
            await userManager.SetAuthenticationTokenAsync(user, "Default","AccessToken",_token);

            return new ServiceResponseWithData<LoginCommandResponse>(
                value: new LoginCommandResponse
                {
                    Token = _token,
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo
                },
                isSuccess: true,
                statusCode: System.Net.HttpStatusCode.OK,
                message: "Uğurlu giriş."
                );

        }
    }
}
