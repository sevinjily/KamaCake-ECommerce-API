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
                .WithMessage("Ad-Soyad boş ola bilməz!")
                .MaximumLength(50)
                .WithMessage("Ad-Soyad maksimum 50 simvoldan ibarət olmalıdır.")
                .MinimumLength(2)
                .WithMessage("Ad-Soyad minimum 2 simvoldan ibarət olmalıdır.")
                .WithName("Ad-Soyad");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email boş ola bilməz!")
                .MaximumLength(60)
                .WithMessage("Email maksimum 60 simvoldan ibarət olmalıdır.")
                .EmailAddress()
                .MinimumLength(8)
                .WithMessage("Email minimum 8 simvoldan ibarət olmalıdır.")
                .WithName("Elektron poçt adresi");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parol boş ola bilməz!")
                .MinimumLength(6).WithMessage("Parol minimum 6 simvoldan ibarət olmalıdır.")
                .Matches(@"[A-Z]+").WithMessage("Parolda ən az bir böyük hərf olmalıdır.")
                .Matches(@"[a-z]+").WithMessage("Parolda ən az bir kiçik hərf olmalıdır.")
                .Matches(@"[0-9]+").WithMessage("Parolda ən az bir rəqəm olmalıdır.")
                .Matches(@"[!?\*._]+").WithMessage("Parolda ən az bir simvol olmalıdır. (!?*._)") 
                .WithName("Parol");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Parol Təkrarı boş ola bilməz!")
                .MinimumLength(6)
                .WithMessage("Parol Təkrarı minimum 6 simvoldan ibarət olmalıdır.")
                .Equal(x => x.Password)
                .WithMessage("Parol Təkrarı Parol ilə eyni olmalıdır.")
                .WithName("Parol Təkrarı");

        }

    }
    
        
}
