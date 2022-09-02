using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Library.core.Model
{
    // Add profile data for application users by adding properties to the Patient class
    public class Patient : GeneralUser
    {

        //http://binaryintellect.net/articles/2f55345c-1fcb-4262-89f4-c4319f95c5bd.aspx
        public byte[]? ImgData { get; set; }

        public int IdNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public EnumGender.Gender Gender { get; set; }

        public bool IsStudent { get; set; }

        public MedicalFile? MedicalFile { get; set; }
    }
}
