using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.AnimalType;

namespace VeterinaryClinic.BLL.Validators
{
    public class AnimalTypeDtoValidator : AbstractValidator<AnimalTypeDto>
    {
        public AnimalTypeDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.AnimalTypeName)
                .NotEmpty().WithMessage("AnimalTypeName is required.")
                .MaximumLength(100).WithMessage("AnimalTypeName must not exceed 100 characters.");
        }
    }
}
