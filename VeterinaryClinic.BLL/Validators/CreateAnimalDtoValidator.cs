using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Animal;

namespace VeterinaryClinic.BLL.Validators
{
    public class CreateAnimalDtoValidator : AbstractValidator<CreateAnimalDto>
    {
        public CreateAnimalDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Animal name is required.")
                .MaximumLength(50).WithMessage("Animal name must be at most 50 characters.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Birth date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Birth date cannot be in the future.");

            RuleFor(x => x.AnimalTypeId)
                .GreaterThan(0).WithMessage("Animal type is required.");
        }
    }
}
