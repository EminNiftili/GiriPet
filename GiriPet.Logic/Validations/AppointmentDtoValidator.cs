using FluentValidation;
using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Validations
{
    public class AppointmentDtoValidator : AbstractValidator<AppointmentDto>
    {
        public AppointmentDtoValidator()
        {
            RuleFor(x => x.PetId)
                .GreaterThan(0).WithMessage("Pet ID must be greater than 0.");

            RuleFor(x => x.WalkerId)
                .GreaterThan(0).WithMessage("Walker ID must be greater than 0.");

            RuleFor(x => x.StartTime)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Start time cannot be in the past.");

            RuleFor(x => x.EndTime)
                .GreaterThan(x => x.StartTime).WithMessage("End time must be after start time.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
