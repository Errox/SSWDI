using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Models
{
    public class Availabilty
    {
        [Key]
        public int Id { get; set; }

        public string EmployeeKey { get; set; }

        public DateTime StartAvailability { get; set; }

        public DateTime StopAvailability { get; set; }
    }
}
