using System;
using System.ComponentModel.DataAnnotations;

namespace Library.core.Model
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description of the note.")]
        public string Description { get; set; }

        [Display(Name = "The date the note was created.")]
        public DateTime CreatedUtc { get; set; }

        [Display(Name = "The employee that created the note.")]
        public Employee Employee { get; set; }

        [Display(Name = "Checked if the patient can see the note.")]
        public bool OpenForPatient { get; set; }
    }

}