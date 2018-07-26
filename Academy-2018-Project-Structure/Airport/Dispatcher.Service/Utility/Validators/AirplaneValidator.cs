using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repository.Models;
using FluentValidation;


namespace BL.Service.Utility.Validators
{
    public class AirplaneValidator : AbstractValidator<Airplane>
    {
        public AirplaneValidator()
        {
            RuleFor(m => m.Name).NotNull().Length(7);
        }

    }
}
