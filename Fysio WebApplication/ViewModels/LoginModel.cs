﻿using System.ComponentModel.DataAnnotations;

namespace Fysio_WebApplication.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
