using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace Core.CrossCuttingCorncerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            ValidationContext<object> context = new ValidationContext<Object>(entity);
            ValidationResult result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
        }
    }
}
