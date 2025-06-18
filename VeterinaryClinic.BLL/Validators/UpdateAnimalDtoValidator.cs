using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Animal;

namespace VeterinaryClinic.BLL.Validators
{
    public class UpdateAnimalDtoValidator : AbstractValidator<AnimalDto>
    {
        public UpdateAnimalDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("Name must be at most 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.BirthDate)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Birth date cannot be in the future.")
                .When(x => x.BirthDate != default);

            RuleFor(x => x.AnimalTypeId)
                .GreaterThan(0).WithMessage("Animal type is required.")
                .When(x => x.AnimalTypeId != 0);
        }
    }
}
