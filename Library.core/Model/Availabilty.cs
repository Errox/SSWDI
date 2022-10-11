using System;
using System.ComponentModel.DataAnnotations;

namespace Library.core.Model
{
    public class Availabilty
    {
        [Key]
        public int Id { get; set; }

        public Employee Employee { get; set; }

        public DateTime StartAvailability { get; set; }

        public DateTime StopAvailability { get; set; }
    }
}
