using System.ComponentModel.DataAnnotations;

namespace MiataProjectTracker.ValidationAttributes
{
    public class TagValidationAttribute : ValidationAttribute
    {
        private static readonly List<string> AllowedTags = new()
        {
            "exhaust",
            "turbo",
            "engine",
            "body",
            "fuel",
            "suspension",
            "brakes",
            "interior",
            "exterior",
            "wheels",
            "intake",
            "cooling",
            "tuning"
        };

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || value is not string tag)
            {
                return new ValidationResult("Tag is required.");
            }

            if (!AllowedTags.Contains(tag))
            {
                return new ValidationResult($"Invalid tag. Allowed tags are: {string.Join(", ", AllowedTags)}");
            }

            return ValidationResult.Success;
        }
    }
}
