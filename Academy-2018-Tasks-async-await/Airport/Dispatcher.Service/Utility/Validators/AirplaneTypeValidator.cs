
using DAL.Repository.Models;
using FluentValidation;

namespace BL.Service.Utility.Validators
{
    public class AirplaneTypeValidator: AbstractValidator<AirplaneType>
    {
        public AirplaneTypeValidator()
        {
            RuleFor(a => a.Model)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
            RuleFor(a => a.Capacity)
                .NotNull()
                .GreaterThan(0);
            RuleFor(a => a.Cargo)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
