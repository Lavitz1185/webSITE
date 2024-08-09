using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;

namespace webSITE.CustomValidationAttribute;

public class SensorKataKasarAttribute : ValidationAttribute, IClientModelValidator
{
    public readonly string[] _daftarKataKasar = new[] 
    { 
        "kontol", "memek", "tolo", "puki", "uti", "mai", "fuck", "kelamin", "kemaluan", "tolol", "la'e", "puqi",  
    };

    public SensorKataKasarAttribute()
    {
        ErrorMessage = "{0} mengandung kata kasar";
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.TryAdd("data-val", "true");
        context.Attributes.TryAdd("data-val-sensorkatakasar", "Mengandung kata kasar");
        context.Attributes.TryAdd("data-val-sensorkatakasar-daftarkatakasar", _daftarKataKasar.ToJson(Newtonsoft.Json.Formatting.Indented));
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
