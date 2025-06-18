using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.HospitalDepartment;

namespace VeterinaryClinic.BLL.Validators
{
    public class HospitalDepartmentDtoValidator : AbstractValidator<HospitalDepartmentDto>
    {
        public HospitalDepartmentDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("DepartmentName is required.")
                .MaximumLength(100).WithMessage("DepartmentName must be at most 100 characters.");
        }
    }
}
