using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class MedicalFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Patient patient { get; set; }

        
        [MaxLength(250), Required]
        [Display(Name ="Beschrijving")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Diagnose Code")]
        public int DiagnosisCode { get; set; }

        public int IntakeTherapistId { get; set; }// Behandeld door //UserID That is either a student or therapist?

        public int IntakeSupervision { get; set; }// ondertoezicht

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}"), Required]
        public DateTime DateOfCreation { get; set; }

        [Required]
        public DateTime? DateOfDischarge { get; set; }

        public Notes? Notes { get; set; }

    }
}
