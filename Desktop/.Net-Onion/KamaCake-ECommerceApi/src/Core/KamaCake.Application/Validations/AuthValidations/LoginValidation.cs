using FluentValidation;
using KamaCake.Application.DTOs.AuthDTOs;

namespace KamaCake.Application.Validations.AuthValidations
{
    public class LoginValidation : AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
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
        }
    }
}
