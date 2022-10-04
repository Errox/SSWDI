using System.ComponentModel.DataAnnotations;

namespace Fysio_Codes.Models
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
