using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fysio_WebApplication.Models
{
    public class PracticeRoom
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

    }
}