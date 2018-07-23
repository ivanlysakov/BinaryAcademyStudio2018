using System;
using DAL.Repository.Models;
using FluentValidation;

namespace BL.Service.Utility.Validators
{
    public class HostessesValidator: AbstractValidator<Hostess>
    {
        public HostessesValidator()
        {
            RuleFor(s => s.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(15);
            RuleFor(s => s.Lastname)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);
            RuleFor(s => s.BirthDay)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now);
        }
    }
}
