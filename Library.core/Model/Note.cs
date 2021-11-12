using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.core.Model
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(250)]
        public string Description { get; set; }
        
        public DateTime CreatedUtc { get; set; }

        public Employee Employee {get; set;}

        public bool OpenForPatient { get; set; }
    }
    
}