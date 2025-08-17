using FluentValidation;
using KamaCake.Application.DTOs.CakeDTOs;

namespace KamaCake.Application.Validations.CakeValidations
{
    public class CreateCakeDTOValidation:AbstractValidator<CreateCakeDTO>
    {
        public CreateCakeDTOValidation()
        {
            // Name
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Cake adı boş ola bilməz")
                .MaximumLength(100).WithMessage("Cake adı maksimum 100 simvol ola bilər");

            // Description 
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description maksimum 500 simvol ola bilər")
                .When(x => !string.IsNullOrEmpty(x.Description));

            // Price
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price 0-dan böyük olmalıdır");

            // DiscountPrice (optional)
            RuleFor(x => x.DiscountPrice)
                .GreaterThanOrEqualTo(0).WithMessage("DiscountPrice mənfi ola bilməz")
                .LessThanOrEqualTo(x => x.Price).WithMessage("DiscountPrice Price-dan böyük ola bilməz")
                .When(x => x.DiscountPrice.HasValue);

            // ImageUrl
            RuleFor(x => x.ImageUrl)
                .MaximumLength(250).WithMessage("ImageUrl maksimum 250 simvol ola bilər");

            // CategoryId
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category seçilməlidir");

        }
       
    }
}
