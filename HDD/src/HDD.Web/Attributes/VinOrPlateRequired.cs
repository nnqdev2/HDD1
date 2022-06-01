using System.ComponentModel.DataAnnotations;

namespace HDD.Web.Attributes
{
    public class VinOrPlateRequired : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public VinOrPlateRequired(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (currentValue == null && comparisonValue == null)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
            //return new ValidationResult(ErrorMessage);
        }
    }
}
