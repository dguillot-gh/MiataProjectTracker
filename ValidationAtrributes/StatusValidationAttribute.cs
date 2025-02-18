
using System.ComponentModel.DataAnnotations;

namespace MiataProjectTracker.ValidationAttributes
{
    public class StatusValidationAttribute : ValidationAttribute
    {
        private static readonly List<string> AllowedStatuses = new()
        {
            "Not Started",
            "In Progress",
            "Done",
        };

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || value is not string status)
            {
                return new ValidationResult("Status is required");
            }

            if (!AllowedStatuses.Contains(status))
            {
                return new ValidationResult(
                    $"Invalid status. Allowed statuses are: {string.Join(", ", AllowedStatuses)}");
            }

            return ValidationResult.Success;
        }

        public static List<string> GetAllowedStatuses()
        {
            return AllowedStatuses;
        }
    }
}