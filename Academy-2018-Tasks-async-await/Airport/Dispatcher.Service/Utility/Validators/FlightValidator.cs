using System;
using DAL.Repository.Models;
using FluentValidation;
namespace BL.Service.Utility.Validators
{
    public class FlightValidator: AbstractValidator<Flight>
    {
        public FlightValidator()
        {
            RuleFor(f => f.Number)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
            RuleForEach(f => f.Tickets)
                .NotNull()
                .NotEmpty();
            RuleFor(f => f.ArrivalTime)
                .NotNull()
                .NotEmpty();
            RuleFor(f => f.Departure)
                .NotNull()
                .NotEmpty();
            RuleFor(f => f.Destination)
                .NotNull()
                .NotEmpty();
        }
    }
}
