﻿using Core.Enums;
using Core.ValidationAttributeExtentions;
using System;
using System.ComponentModel.DataAnnotations;


namespace Fysio_WebApplication.ViewModels
{
    public class RegisterPatientModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Sur Name")]
        public string SurName { get; set; }

        [Display(Name = "Please select a image.")]
        public byte[] ImgData { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Please fill in your date of birth.")]
        [MinAge(16)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Pick a gender.")]
        public EnumGender.Gender Gender { get; set; }

        [Required]
        [Display(Name = "Is the user a student?")]
        public bool IsStudent { get; set; }

        public string ReturnUrl { get; set; }
    }

}
