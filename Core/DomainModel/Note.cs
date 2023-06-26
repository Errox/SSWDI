using System.ComponentModel.DataAnnotations;

namespace Core.DomainModel
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description.")]
        public string Description { get; set; }

        [Display(Name = "Creation date.")]
        public DateTime CreatedUtc { get; set; }

        [Display(Name = "Employee.")]
        public Employee Employee { get; set; }

        [Display(Name = "Open for patient.")]
        public bool OpenForPatient { get; set; }
    }

}