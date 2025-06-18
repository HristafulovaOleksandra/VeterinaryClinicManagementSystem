using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.AnimalDisease;

namespace VeterinaryClinic.BLL.Validators
{
    public class CreateAnimalDiseaseDtoValidator : AbstractValidator<CreateAnimalDiseaseDto>
    {
        public CreateAnimalDiseaseDtoValidator()
        {
            RuleFor(x => x.DiseaseName)
                .NotEmpty().WithMessage("Disease name is required.")
                .MaximumLength(100).WithMessage("Disease name must be at most 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Description can't exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}
