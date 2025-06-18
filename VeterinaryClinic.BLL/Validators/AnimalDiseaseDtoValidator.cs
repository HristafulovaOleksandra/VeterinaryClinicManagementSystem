using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.AnimalDisease;

namespace VeterinaryClinic.BLL.Validators
{
    public class AnimalDiseaseDtoValidator : AbstractValidator<AnimalDiseaseDto>
    {
        public AnimalDiseaseDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.DiseaseName)
                .NotEmpty().WithMessage("Disease name is required.")
                .MaximumLength(100).WithMessage("Disease name must be at most 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Description can't exceed 500 characters.")
                .When(x => x.Description != null);
        }
    }
}
