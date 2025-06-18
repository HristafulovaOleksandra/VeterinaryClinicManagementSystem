using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.AnimalMedicalRecord;

namespace VeterinaryClinic.BLL.Validators
{
    public class CreateAnimalMedicalRecordDtoValidator : AbstractValidator<CreateAnimalMedicalRecordDto>
    {
        public CreateAnimalMedicalRecordDtoValidator()
        {
            RuleFor(x => x.AnimalId)
                .GreaterThan(0).WithMessage("AnimalId must be greater than 0.");
            RuleFor(x => x.DiagnosisDate)
                .NotEmpty().WithMessage("Diagnosis date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Diagnosis date cannot be in the future.");
            RuleFor(x => x.TreatmentNotes)
                .MaximumLength(1000)
                .WithMessage("Treatment notes must be at most 1000 characters.")
                .When(x => !string.IsNullOrEmpty(x.TreatmentNotes));
            RuleFor(x => x.AdmissionDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Admission date cannot be in the future.")
                .When(x => x.AdmissionDate.HasValue);
            RuleFor(x => x.DischargeDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Discharge date cannot be in the future.")
                .When(x => x.DischargeDate.HasValue);
            RuleFor(x => x)
                .Must(x => !x.AdmissionDate.HasValue || !x.DischargeDate.HasValue || x.DischargeDate >= x.AdmissionDate)
                .WithMessage("Discharge date must be after or equal to admission date.");
        }
    }

}
