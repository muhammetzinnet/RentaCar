using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId);
            RuleFor(r => r.CustomerId);
            RuleFor(r => r.RentDate);
            RuleFor(r => r.Id);
            RuleFor(r => r.ReturnDate);
        }
    }
}
