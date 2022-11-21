using Core.Enums;
using Core.ValidationAttributeExtentions;
using Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Core.DomainModel
{
    // Add profile data for application users by adding properties to the Patient class
    public class Patient : ApplicationUser
    {
        [ForeignKey("ApplicationUser")]
        public string PatientId { get; set; }

        public string CustomerType { get; set; }

        //http://binaryintellect.net/articles/2f55345c-1fcb-4262-89f4-c4319f95c5bd.aspx
        [Display(Name = "Patients image of their face.")]
        public byte[]? ImgData { get; set; }

        [Display(Name = "Patients ID number")]
        public int IdNumber { get; set; }

        [MinAge(16)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Patients gender")]
        public EnumGender.Gender Gender { get; set; }

        [Display(Name = "If patient is a student.")]
        public bool IsStudent { get; set; }

        public MedicalFile? MedicalFile { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
