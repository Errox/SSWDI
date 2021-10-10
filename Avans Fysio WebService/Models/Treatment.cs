using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Fysio_WebService.Models
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Code { get; set; }
        [StringLength(255), Required]
        public string Description { get; set; }
        [Required]
        public bool ExplanationRequired { get; set; }
    }
}
