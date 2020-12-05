using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Filters
{
    public class OldActorsAttribute: ValidationAttribute
    {
        public OldActorsAttribute(int year)
        {
            Year = year;
        }

        public int Year { get; }

        public string GetErrorMessage() =>
            $"Actors must have a birthday year no later than {Year}.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthYear = ((DateTime)value).Year;

            if (birthYear < Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
