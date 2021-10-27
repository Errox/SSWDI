using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Models
{
    public class Appointment
    {
        [Key] 
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string EmployeeId { get; set; }
        public DateTime Date { get; set; }
    }
}
