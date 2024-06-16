using System.ComponentModel.DataAnnotations;

namespace HarshaApi1.CustomValidations
{
    public class MinmumYearValidations:ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime? date = value as DateTime?;
            if(date is not null)
            {
                if (date.Value.Year > 2012)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(string.Format(ErrorMessage?? DefaultErrorMessage, "2012"));
                }
            }
           return null;
        }
    }
}
