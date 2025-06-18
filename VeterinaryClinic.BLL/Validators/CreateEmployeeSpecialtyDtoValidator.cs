using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.EmployeeSpecialty;

namespace VeterinaryClinic.BLL.Validators
{
    public class CreateEmployeeSpecialtyDtoValidator : AbstractValidator<CreateEmployeeSpecialtyDto>
    {
        public CreateEmployeeSpecialtyDtoValidator()
        {
            RuleFor(x => x.SpecialtyName)
                .NotEmpty().WithMessage("SpecialtyName is required.")
                .MaximumLength(100).WithMessage("SpecialtyName must be at most 100 characters.");
        }
    }
}
