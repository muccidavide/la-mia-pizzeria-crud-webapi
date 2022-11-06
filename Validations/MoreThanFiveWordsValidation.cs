
using System;
using System.Globalization;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;


namespace la_mia_pizzeria_crud_mvc.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    sealed public class MoreThanFiveWordsValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null && ValidationResult.Success is not null)
                return ValidationResult.Success;

            string? fieldValue = value as string;

            if (fieldValue is not null)
            {
                int wordsNumber = fieldValue.Trim().Split(' ').Length;
                if (wordsNumber < 5 || ValidationResult.Success is null)
                    return new ValidationResult("Il campo deve contenere almeno 5 parole");
                else

                    return ValidationResult.Success;
            }
            else {
                return new ValidationResult("Il campo deve contenere almeno 5 parole");

            }

        }
    }
}
