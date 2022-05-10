using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Attribuites
{
    public class DateTimeIsValidAttribute : ValidationAttribute
    {

        private readonly DateTime _minValue = DateTime.Now;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (DateTime)value;

            if (currentValue >= _minValue)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);

        }

    }
}
