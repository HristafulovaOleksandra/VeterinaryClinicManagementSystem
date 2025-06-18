using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.HospitalDepartment;

namespace VeterinaryClinic.BLL.Validators
{
    public class CreateHospitalDepartmentDtoValidator : AbstractValidator<CreateHospitalDepartmentDto>
    {
        public CreateHospitalDepartmentDtoValidator()
        {
            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("DepartmentName is required.")
                .MaximumLength(100).WithMessage("DepartmentName must be at most 100 characters.");
        }
    }
}
