using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class Therapist : Employee
    {
        [Range(1000000000, 99999999999)]
        public int BigNumber { get; set; }
    }
}
