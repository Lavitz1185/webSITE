using System.ComponentModel.DataAnnotations;

namespace webSITE.CustomValidationAttribute;

public class SensorKataKasarAttribute : ValidationAttribute
{
    public readonly string[] _daftarKataKasar = new[] 
    { 
        "babi", "kontol", "memek", "tolo", "puki", "uti", "mai" 
    };

    public SensorKataKasarAttribute()
    {
        ErrorMessage = "{0} mengandung kata kasar";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null || value is not string s || string.IsNullOrEmpty(s))
            return ValidationResult.Success;

        var words = s.ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var isKataKasar = words.Any(w => _daftarKataKasar.Contains(w));

        if (isKataKasar)
        {
            string[]? memberNames = validationContext.MemberName is string memberName
                ? new[] { memberName }
                : null;

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
        }

        return ValidationResult.Success;
    }
}
