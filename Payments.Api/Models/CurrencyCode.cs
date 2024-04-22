using System.ComponentModel.DataAnnotations;

namespace Payments.Api.Models;

public class CurrencyValidator : ValidationAttribute
{
    private static readonly HashSet<string> ValidCurrencyCodes = new()
    {
        // Add all Currecy Codes
        "USD", "EUR", "GBP", "JPY", "CAD", "AUD", "SEK", "ZWL"
    };

    public override bool IsValid(object? value)
    {
        if (value is null)
        {
            return false;
        }
        
        return ValidCurrencyCodes.Contains(value);
    }
}