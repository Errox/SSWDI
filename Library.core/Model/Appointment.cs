﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Library.core.Model
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public Patient Patient { get; set; }

        public Employee Employee { get; set; }

        public Availability TimeSlot { get; set; }

    }
}
