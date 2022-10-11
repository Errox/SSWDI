using System.ComponentModel.DataAnnotations;

namespace Library.core.ViewModels
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
