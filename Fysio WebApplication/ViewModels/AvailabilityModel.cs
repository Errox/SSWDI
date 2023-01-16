using System;
using System.ComponentModel.DataAnnotations;

namespace Fysio_WebApplication.ViewModels
{
    public class AvailabilityModel
    {
        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateStop { get; set; }

        [Required]
        public DateTime DateTimeStart { get; set; }

        [Required]
        public DateTime DateTimeStop { get; set; }

        public string ReturnUrl { get; set; } = "/";
        public bool IsValid { get; set; }
    }
}
