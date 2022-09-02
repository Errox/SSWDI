using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
