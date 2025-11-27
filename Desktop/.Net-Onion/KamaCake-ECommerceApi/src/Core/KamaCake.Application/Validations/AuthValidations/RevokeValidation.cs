using FluentValidation;
using KamaCake.Application.Features.Commands.AuthCommands.Revoke;

namespace KamaCake.Application.Validations.AuthValidations
{
    public class RevokeValidation:AbstractValidator<RevokeCommand>
    {
        public RevokeValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty().WithMessage("Email boş ola bilməz!");
        }
    }
}
