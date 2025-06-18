using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.HospitalRoom;

namespace VeterinaryClinic.BLL.Validators
{
    public class CreateHospitalRoomDtoValidator : AbstractValidator<CreateHospitalRoomDto>
    {
        public CreateHospitalRoomDtoValidator()
        {
            RuleFor(x => x.RoomNumber)
                .NotEmpty().WithMessage("RoomNumber is required.")
                .MaximumLength(50).WithMessage("RoomNumber must be at most 50 characters.");

            When(x => x.DepartmentId.HasValue, () =>
            {
                RuleFor(x => x.DepartmentId.Value)
                    .GreaterThan(0).WithMessage("DepartmentId must be greater than 0.");
            });

            When(x => x.AnimalTypeId.HasValue, () =>
            {
                RuleFor(x => x.AnimalTypeId.Value)
                    .GreaterThan(0).WithMessage("AnimalTypeId must be greater than 0.");
            });

            When(x => x.CurrentAnimalId.HasValue, () =>
            {
                RuleFor(x => x.CurrentAnimalId.Value)
                    .GreaterThan(0).WithMessage("CurrentAnimalId must be greater than 0.");
            });
        }
    }
}
