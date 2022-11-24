using System.ComponentModel.DataAnnotations;

namespace Core.DomainModel
{
    public class MedicalFile
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Diagnose Code")]
        public int DiagnosisCode { get; set; }

        [Display(Name = "Intake being performed by a therapist. Can be a student or therapist.")]
        public Employee IntakeTherapistId { get; set; }// Behandeld door //UserID That is either a student or therapist

        [Display(Name = "The employee that supervisions this medical file.")]
        public Employee IntakeSupervision { get; set; }// ondertoezicht, Also a UserId from Identity

        [Display(Name = "The date the the medical file was created.")]
        public DateTime DateOfCreation { get; set; }

        [Display(Name = "Date of discharge")]
        public DateTime? DateOfDischarge { get; set; }

        [Display(Name = "Patient's email. ")]
        [EmailAddress]
        public string? PatientEmail { get; set; }

        [Display(Name = "Notes of the medical file")]
        public ICollection<Note> Notes { get; set; }

        [Display(Name = "Treatment Plans")]
        public ICollection<TreatmentPlan> TreatmentPlans { get; set; }

    }
}
