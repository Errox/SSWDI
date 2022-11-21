using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DomainModel
{
    public class Availability
    {
        [Key]
        public int Id { get; set; }

        public Employee Employee { get; set; }

        // These will be time slots that are available for the employee to work with.
        // Value will start at this time. 
        public DateTime StartAvailability { get; set; }

        // And stop at this time. 
        public DateTime StopAvailability { get; set; }

        // If the timeslot is available for the patient to pick.
        public bool IsAvailable { get; set; }

        // What patient already saved this timeslot.
        public Patient? Patient { get; set; }
    }
}
