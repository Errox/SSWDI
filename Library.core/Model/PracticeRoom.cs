using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.core.Model
{
    public class PracticeRoom
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

    }
}