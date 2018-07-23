
using DAL.Repository.Models;
using FluentValidation;

namespace BL.Service.Utility.Validators
{
    public class TicketValidator: AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(t => t.FlightNumber)
                .NotNull()
                .NotEmpty();
            RuleFor(t => t.Price)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
