using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria.Utils.Validation
{
    public class NumeroMaggioreDi0ValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
           object value, ValidationContext validationContext)
        {
            int prezzo = (int)value;
            if (prezzo < 0 )
            {
                return new ValidationResult("Il prezzo deve essere maggiore di 0");
            }
            return ValidationResult.Success;
        }
    }
}
