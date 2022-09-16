using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Library.core.Model
{
    // Add profile data for application users by adding properties to the Employee class
    public class Employee : ApplicationUser
    {
        [ForeignKey("ApplicationUser")]
        public string EmployeeId { get; set; }

        public string? EmployeeType { get; set; }

        public int? WorkerNumber { get; set; }

        public int? BIGNumber { get; set; }

        public int? StudentNumber { get; set; }

        [Required]
        public bool IsStudent { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
