using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Avans_Fysio_WebApplicatie.Models
{
    public class Employee : IdentityUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        [DataType(DataType.PhoneNumber), Required]
        public PhoneAttribute PhoneNumber { get; set; }


    }
}
