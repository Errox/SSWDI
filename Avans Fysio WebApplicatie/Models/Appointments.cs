using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class Appointments
    {
        [Key] 
        public int Id { get; set; }

        public Patient Patient { get; set; }

        public int EmployeeId { get; set; }
    }
}
