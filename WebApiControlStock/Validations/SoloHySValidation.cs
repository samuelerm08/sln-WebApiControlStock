using System.ComponentModel.DataAnnotations;

namespace WebApiControlStock.Validations
{
    public class SoloHySValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var lineaProducto = value.ToString();
            

            if (lineaProducto != "H".ToUpper() && lineaProducto != "S".ToUpper())
            {
                return new ValidationResult("Las líneas prooducto solo acepta caracteres H o S.");
            }
            return ValidationResult.Success;
        }
    }
}
