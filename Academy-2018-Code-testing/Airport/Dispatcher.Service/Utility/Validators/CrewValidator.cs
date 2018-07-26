using System;
using DAL.Repository.Models;
using FluentValidation;

namespace BL.Service.Utility.Validators
{
    public class CrewValidator: AbstractValidator<Crew>
    {
        public CrewValidator()
        {
            RuleFor(c => c.CrewNumber)
                .NotNull();
        }
    }
}
