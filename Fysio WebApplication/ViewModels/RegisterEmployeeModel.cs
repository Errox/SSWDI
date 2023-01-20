using System.ComponentModel.DataAnnotations;

namespace Fysio_WebApplication.ViewModels
{
    public class RegisterEmployeeModel
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

        [Range(1000000, 9999999, ErrorMessage = "Your Registration Number can only be 7 Numbers long. That means a number between 1000000, 9999999")]
        [Display(Name = "Registration Number")]
        public int StudentBIGNumber { get; set; }

        [Required]
        [Display(Name = "Is the user a student?")]
        public bool IsStudent { get; set; }

        public string ReturnUrl { get; set; }

    }
}
