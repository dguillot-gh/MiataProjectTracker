using System.ComponentModel.DataAnnotations;

namespace MiataProjectTracker.ValidationAttributes
{
    public class CategoryValidationAttribute : ValidationAttribute
    {
        public static string[] GetAllowedCategories()
        {
            return new[]
            {
                "Engine",
                "Suspension",
                "Electrical",
                "Drivetrain",
                "Brakes",
                "Cooling",
                "Fuel",
                "Other",
                "Turbo"
            };
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Category is required");
            }

            var category = value.ToString();
            if (!GetAllowedCategories().Contains(category))
            {
                return new ValidationResult("Invalid category selected");
            }

            return ValidationResult.Success;
        }
    }
}