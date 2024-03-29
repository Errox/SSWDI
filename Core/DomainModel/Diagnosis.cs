﻿using System.ComponentModel.DataAnnotations;

namespace Core.DomainModel
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        [Range(1000, 9999), Required]
        public int Code { get; set; }
        [StringLength(255), Required]
        public string BodyLocation { get; set; }
        [StringLength(255), Required]
        public string Pathology { get; set; }
    }
}
