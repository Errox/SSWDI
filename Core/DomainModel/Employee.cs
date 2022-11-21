using Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DomainModel
{
    // Add profile data for application users by adding properties to the Employee class
    public class Employee : ApplicationUser
    {
        [ForeignKey("ApplicationUser")]
        public string EmployeeId { get; set; }

        public string? EmployeeType { get; set; }

        [Required]
        [Display(Name = "Worker number.")]
        public int? WorkerNumber { get; set; }

        [Display(Name = "Big number of the employee.")]
        [Range(11, 11, ErrorMessage = "A BIG number is always 11 numbers.")]
        public int? BIGNumber { get; set; }

        [Display(Name = "Student number of the employee.")]
        [Range(6, 8, ErrorMessage = "A student number is always between 6 and 8.")]
        public int? StudentNumber { get; set; }

        [Display(Name = "Is employee student or not.")]
        [Required]
        public bool IsStudent { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
