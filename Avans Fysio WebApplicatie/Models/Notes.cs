using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(250), Required]
        public string Description { get; set; }
        
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }

        //Public Therapist Therapist {get; set;} 

        public Boolean OpenForPatient { get; set; }
    }
    
}