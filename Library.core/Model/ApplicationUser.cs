﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library.core.Model
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string SurName { get; set; }
    }
}