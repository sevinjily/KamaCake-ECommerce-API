using FluentValidation;
using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Domain.Entities;

namespace KamaCake.Application.Validations.CategoryValidations
{
    public class CreateCategoryValidation : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidation() 
        {
            // Name
            RuleFor(x => x.CategoryName)
               .NotEmpty().WithMessage("Category adı boş ola bilməz")
               .MaximumLength(100).WithMessage("Category adı maksimum 100 simvol ola bilər");

            // Description 
            RuleFor(x => x.CategoryDescription)
                 .MaximumLength(500).WithMessage("Category təsviri maksimum 500 simvol ola bilər")
                 .When(x => !string.IsNullOrEmpty(x.CategoryDescription));
        }
    }
}
