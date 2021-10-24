using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fysio_WebApplication.Abstract;

namespace Fysio_WebApplication.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        
        [MaxLength(250)]
        public string FirstName { get; set; }
        
        [MaxLength(250)]
        public string SurName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //http://binaryintellect.net/articles/2f55345c-1fcb-4262-89f4-c4319f95c5bd.aspx
        public byte[]? ImgData { get; set; }
        
        public int IdNumber { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        [Column("Gender")]
        public string GenderString
        {
            get { return Gender.ToString(); }
            private set => Gender = value.ParseEnum<EnumGender.Gender>();
        }

        [NotMapped]
        public EnumGender.Gender Gender { get; set; }

        
        public bool IsStudent { get; set; }

        public MedicalFile? MedicalFile { get; set; }

        public ICollection<Appointment> Appointments { get; set; }


    }
}