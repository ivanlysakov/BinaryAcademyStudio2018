using System;
using DAL.Repository.Models;
using FluentValidation;
namespace BL.Service.Utility.Validators
{
    public class PilotValidator: AbstractValidator<Pilot>
    {
        public PilotValidator()
        {
            RuleFor(p => p.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(15);
            RuleFor(p => p.Lastname)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);
            RuleFor(p => p.BirthDay)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now);
            RuleFor(p => p.Experience)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
