using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace lan2.Models.Validation
{
    public class ValidateEmailAttribute : ValidationAttribute
    {
        private static readonly Regex NameRegex = new Regex(@"^[a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+){1,}$", RegexOptions.Compiled);

        public ValidateEmailAttribute()
        {
            const string defaultErrorMessage = "Error with Email";
            ErrorMessage ??= defaultErrorMessage;
        }
        protected override ValidationResult? IsValid(object? value,
                                          ValidationContext validationContext)
        {
            
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Email is required.");
            }
            return NameRegex.IsMatch(value.ToString())
           ? ValidationResult.Success
           : new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));



        }
    }
}