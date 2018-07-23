using System;
using DAL.Repository.Models;
using FluentValidation;

namespace BL.Service.Utility.Validators
{
    public class DepartureValidator: AbstractValidator<Departure>
    {
        public DepartureValidator()
        {
            RuleFor(d => d.Airplane)
                .NotNull();
            RuleFor(d => d.Crew)
                .NotNull();
            RuleFor(d => d.Time)
                .NotNull();
            RuleFor(d => d.FlightNumber)
                .NotNull()
                .NotEmpty()
                .MaximumLength(8);
        }
    }
}
