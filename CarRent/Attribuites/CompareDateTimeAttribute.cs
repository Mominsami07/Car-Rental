using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Attribuites
{
    public class CompareDateTimeAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public CompareDateTimeAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var returnDate = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var rentDate = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (returnDate > rentDate)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);

            
        }

    }
}
