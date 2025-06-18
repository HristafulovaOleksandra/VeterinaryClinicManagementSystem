using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.AnimalMedicalRecord;

namespace VeterinaryClinic.BLL.Validators
{
    public class AnimalMedicalRecordDtoValidator : AbstractValidator<AnimalMedicalRecordDto>
    {
        public AnimalMedicalRecordDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.AnimalId)
                .GreaterThan(0).WithMessage("AnimalId must be greater than 0.");
            RuleFor(x => x.DiagnosisDate)
                .NotEmpty().WithMessage("Diagnosis date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Diagnosis date cannot be in the future.");
        }
    }

}
