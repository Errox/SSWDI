using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DomainModel
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public Patient Patient { get; set; }

        public Employee Employee { get; set; }

        public Availability TimeSlot { get; set; }

    }
}
