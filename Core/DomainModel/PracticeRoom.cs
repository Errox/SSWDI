﻿using System.ComponentModel.DataAnnotations;

namespace Core.DomainModel
{
    public class PracticeRoom
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Display(Name = "Name of the practice room.")]
        public string Name { get; set; }

    }
}