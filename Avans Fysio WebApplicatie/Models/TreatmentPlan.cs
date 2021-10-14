using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class TreatmentPlan
    {
        [Key]
        public int Id { get; set; }

        //This is the type of treatment from the Vektis list
        public string Type { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public PracticeRoom? PracticeRoom { get; set; }
        //These are the bijzonderheden a patient might have.
        public string Particularities { get; set; }
        //The ID of the one treating the person. Maybe switch it to the Id of the employee IdentityUser
        public int TreatmentPerformedBy { get; set; }
        public DateTime TreatmentDate { get; set; }
        public int AmountOfTreatmentsPerWeek { get; set; }
    }
}
