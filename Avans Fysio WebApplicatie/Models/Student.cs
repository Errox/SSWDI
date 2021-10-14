using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class Student : Employee
    {
        [Range(1000000,9999999)]
        public int StudentNumber { get; set; }
    }
}
