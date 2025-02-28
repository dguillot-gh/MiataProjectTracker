using System.ComponentModel.DataAnnotations;

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
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return new ValidationResult("At least one tag is required.");
        }

        var tags = value.ToString()!.Split(',', StringSplitOptions.RemoveEmptyEntries);
        var invalidTags = tags.Where(t => !AllowedTags.Contains(t.Trim().ToLower())).ToList();

        if (invalidTags.Any())
        {
            return new ValidationResult($"Invalid tags: {string.Join(", ", invalidTags)}");
        }

        return ValidationResult.Success;
    }
}