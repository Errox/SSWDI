using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(250)]
        public string Description { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }

        public Therapist Therapist {get; set;}

        public bool OpenForPatient { get; set; }

        public MedicalFile MedicalFile { get; set; }
    }
    
}