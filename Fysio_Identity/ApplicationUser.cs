using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity
{
    // Kept in Identity to fix circulair reference error
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string SurName { get; set; }
    }
}