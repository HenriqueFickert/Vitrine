using System.ComponentModel.DataAnnotations;

namespace VitrineAPI.Application.Attributes
{
    public class ValidaGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is Guid && !Guid.Empty.Equals(value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}