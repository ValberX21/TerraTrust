using FluentValidation;
using TerraTrust.Business.Commands;

namespace TerraTrust.Business.Validators
{
    public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Property name is required.")
                .MaximumLength(100).WithMessage("Property name must be 100 characters or less.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid property type.");

            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("Owner ID must be greater than zero.");
        }
    }
}
