using System.ComponentModel.DataAnnotations;
using System;

namespace WebApiControlStock.Validations
{
    public class MayorACeroValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var precio = Convert.ToInt32(value);

            if (precio < 1)
            {
                return new ValidationResult("El precio debe ser mayor a 0");
            }

            return ValidationResult.Success;
        }
    }
}
