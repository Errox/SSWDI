using System.ComponentModel.DataAnnotations;

namespace Core.DomainModel
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Patient Patient { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Availability TimeSlot { get; set; }

    }
}
