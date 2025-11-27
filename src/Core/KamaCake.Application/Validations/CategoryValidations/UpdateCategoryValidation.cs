using FluentValidation;
using KamaCake.Application.DTOs.CategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.Validations.CategoryValidations
{
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryValidation()
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
