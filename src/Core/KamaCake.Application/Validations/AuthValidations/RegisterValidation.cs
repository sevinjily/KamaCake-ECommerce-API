using FluentValidation;
using KamaCake.Application.DTOs.AuthDTOs;
using KamaCake.Application.Features.Commands.AuthCommands.Register;

namespace KamaCake.Application.Validations.AuthValidations
{

    public class RegisterValidation:AbstractValidator<RegisterDTO>
    {
        public RegisterValidation()
        {
            RuleFor(x=>x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("Ad Soyad");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(60)
                .EmailAddress()
                .MinimumLength(8)
                .WithName("Elektron poçt adresi");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithName("Parol");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6)
                .Equal(x => x.Email)
                .WithName("Parol Təkrari");

        }

    }
    
        
}
