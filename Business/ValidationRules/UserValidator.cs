using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Validators;

namespace Business.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Id);
            RuleFor(u => u.FirstName);
            RuleFor(u => u.LastName);
            RuleFor(u => u.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(u => u.Status);
        }
    }
}
