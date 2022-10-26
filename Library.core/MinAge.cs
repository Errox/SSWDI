using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.core
{
    public class MinAge : ValidationAttribute
    {
        private readonly int _minAge;

        public MinAge(int minAge)
        {
            _minAge = minAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var date = (DateTime)value;

            if (date.AddYears(_minAge) > DateTime.Now)
            {
                return new ValidationResult($"You must be at least {_minAge} years old to register.");
            }

            return ValidationResult.Success;
        }
    }
}
