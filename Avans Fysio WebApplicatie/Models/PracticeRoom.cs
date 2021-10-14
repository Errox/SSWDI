using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class PracticeRoom
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        public ICollection<TreatmentPlan> TreatmentPlans { get; set; }
    }
}