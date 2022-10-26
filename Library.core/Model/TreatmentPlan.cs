using System;
using System.ComponentModel.DataAnnotations;

namespace Library.core.Model
{
    public class TreatmentPlan
    {
        [Key]
        public int Id { get; set; }

        //This is the type of treatment from the Vektis list
        public int Type { get; set; }
        [Display(Name = "Description of the treament plan.")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Display(Name = "Practice room.")]
        public PracticeRoom? PracticeRoom { get; set; }

        [Display(Name = "Particularities")]
        [Required]
        public string Particularities { get; set; }

        [Display(Name = "Treatment is performed by")]
        [Required]
        public Employee TreatmentPerformedBy { get; set; }

        [Display(Name = "The date the treatment should be treated.")]
        [Required]
        [AfterToday]
        public DateTime TreatmentDate { get; set; }

        [Required]
        [Display(Name = "The amount of times the treatment should be treated.")]
        [Range(0, 14, ErrorMessage = "Please enter valid Number between 0 and 14.")]
        public int AmountOfTreatmentsPerWeek { get; set; }
    }
}
