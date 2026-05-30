using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment1.CustomValidation
{
    public class NumericIdValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Id is required");
            }

            long number;

            bool isValid = long.TryParse(value.ToString(), out number);

            if (isValid)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                "Id must contain only numeric value");
        }
    }
}
