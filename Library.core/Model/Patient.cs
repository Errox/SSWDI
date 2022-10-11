using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.core.Model
{
    // Add profile data for application users by adding properties to the Patient class
    public class Patient : ApplicationUser
    {
        [ForeignKey("ApplicationUser")]
        public string PatientId { get; set; }

        public string CustomerType { get; set; }

        //http://binaryintellect.net/articles/2f55345c-1fcb-4262-89f4-c4319f95c5bd.aspx
        public byte[]? ImgData { get; set; }

        public int IdNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public EnumGender.Gender Gender { get; set; }

        public bool IsStudent { get; set; }

        public MedicalFile? MedicalFile { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
