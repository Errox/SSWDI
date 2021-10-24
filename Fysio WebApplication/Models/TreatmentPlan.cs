using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Models
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

        public string Particularities { get; set; }

        public string TreatmentPerformedBy { get; set; }

        public DateTime TreatmentDate { get; set; }

        public int AmountOfTreatmentsPerWeek { get; set; }
    }
}
