using System.ComponentModel.DataAnnotations;

namespace Core.ValidationAttributeExtentions
{
    public class AfterToday : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var date = (DateTime)value;

            if (date < DateTime.Now)
            {
                return new ValidationResult($"Date must be in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
