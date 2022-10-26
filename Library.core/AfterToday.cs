﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.core
{
    public class AfterToday : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var date = (DateTime)value;

            if (date < DateTime.Now)
            {
                return new ValidationResult($"Date must be in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
