using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Avans_Fysio_WebApplicatie.Abstract;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        
        [MaxLength(250), Required]
        public string FirstName { get; set; }
        
        [MaxLength(250), Required]
        public string SurName { get; set; }

        [DataType(DataType.PhoneNumber), Required]
        public PhoneAttribute PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }

        //http://binaryintellect.net/articles/2f55345c-1fcb-4262-89f4-c4319f95c5bd.aspx
        public byte[]? ImgData { get; set; }

        [Required]
        public int IdNumber { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}"), Required]
        public DateTime DateOfBirth { get; set; }

        [Column("Gender")]
        public string GenderString
        {
            get { return Gender.ToString(); }
            private set => Gender = value.ParseEnum<EnumGender.Gender>();
        }

        [NotMapped]
        public EnumGender.Gender Gender { get; set; }

        [Required]
        public int IsStudent { get; set; }

        public MedicalFile? MedicalFile { get; set; }
    }
}