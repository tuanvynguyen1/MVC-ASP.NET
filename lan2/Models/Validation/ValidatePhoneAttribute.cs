using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace lan2.Models.Validation
{
    public class ValidatePhoneAttribute : ValidationAttribute
    {
        private static readonly Regex NameRegex = new Regex(@"^0[1-9]{1}[0-9]{8}$", RegexOptions.Compiled);

        public ValidatePhoneAttribute()
        {
            const string defaultErrorMessage = "Phone number field is required.";
            ErrorMessage ??= defaultErrorMessage;
        }

        protected override ValidationResult? IsValid(object? value,
                                          ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Phone number field is required.");
            }
            return NameRegex.IsMatch(value.ToString())
           ? ValidationResult.Success
           : new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
