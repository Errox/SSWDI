using System.ComponentModel.DataAnnotations;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class PracticeRoom
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250), Required]
        public string Name { get; set; }
    }
}