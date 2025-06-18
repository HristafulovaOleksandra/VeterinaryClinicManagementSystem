using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.EmployeeSpecialty;

namespace VeterinaryClinic.BLL.Validators
{
    public class EmployeeSpecialtyDtoValidator : AbstractValidator<EmployeeSpecialtyDto>
    {
        public EmployeeSpecialtyDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.SpecialtyName)
                .NotEmpty().WithMessage("SpecialtyName is required.")
                .MaximumLength(100).WithMessage("SpecialtyName must be at most 100 characters.");
        }
    }
}
