using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Library.core.Model
{
    // Add profile data for application users by adding properties to the Employee class
    public class Employee : IdentityUser
    {
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public int? WorkerNumber { get; set; }

        public int? BIGNumber { get; set; }

        public int? StudentNumber { get; set; }

        [Required]
        public bool IsStudent { get; set; }
    }
}
