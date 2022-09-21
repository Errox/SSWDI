using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Library.core.Model
{
    public class MedicalFile
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(250)]
        [Display(Name ="Beschrijving")]
        public string Description { get; set; }
        
        [Display(Name ="Diagnose Code")]
        public int DiagnosisCode { get; set; }

        public Employee IntakeTherapistId { get; set; }// Behandeld door //UserID That is either a student or therapist

        public Employee IntakeSupervision { get; set; }// ondertoezicht, Also a UserId from Identity

        public DateTime DateOfCreation { get; set; }
        
        public DateTime? DateOfDischarge { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<TreatmentPlan> TreatmentPlans { get; set; }

    }
}
