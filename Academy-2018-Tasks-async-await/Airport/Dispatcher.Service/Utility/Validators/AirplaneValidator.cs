using System;
using DAL.Repository.Models;
using FluentValidation;

namespace BL.Service.Utility.Validators
{
    public class AirplaneValidator: AbstractValidator<Airplane>
    {
        public AirplaneValidator()
        {
            RuleFor(a => a.Lifetime)
                .NotNull()
                .GreaterThan(0);
            RuleFor(a => a.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(25);
            RuleFor(a => a.CreationDate)
                .NotNull()
                .LessThan(DateTime.Now);
            
        }
    }
}
