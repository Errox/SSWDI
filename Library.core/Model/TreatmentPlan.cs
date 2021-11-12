using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.core.Model
{
    public class TreatmentPlan
    {
        [Key]
        public int Id { get; set; }

        //This is the type of treatment from the Vektis list
        public int Type { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public PracticeRoom? PracticeRoom { get; set; }

        public string Particularities { get; set; }

        public Employee TreatmentPerformedBy { get; set; }

        public DateTime TreatmentDate { get; set; }

        public int AmountOfTreatmentsPerWeek { get; set; }
    }
}
