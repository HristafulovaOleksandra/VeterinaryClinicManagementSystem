using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Owner;

namespace VeterinaryClinic.BLL.Validators
{
    public class CreateOwnerDtoValidator : AbstractValidator<CreateOwnerDto>
    {
        public CreateOwnerDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must be at most 100 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required.")
                .Matches(@"^\+?\d{7,15}$").WithMessage("PhoneNumber is invalid. It should contain only digits and optional leading '+'.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address must be at most 200 characters.")
                .When(x => !string.IsNullOrEmpty(x.Address));
        }
    }
}
