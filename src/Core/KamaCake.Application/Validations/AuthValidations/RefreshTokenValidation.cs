using FluentValidation;
using KamaCake.Application.Features.Commands.AuthCommands.RefreshToken;

namespace KamaCake.Application.Validations.AuthValidations
{
    public class RefreshTokenValidation:AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenValidation()
        {
            RuleFor(x => x.AccessToken).NotEmpty();
            RuleFor(x => x.RefreshToken).NotEmpty();


        }
    }
}
