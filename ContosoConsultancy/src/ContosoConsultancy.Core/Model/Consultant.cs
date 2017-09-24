﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoConsultancy.Core.Model
{
    public class Consultant
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public DateTime? DisengagedDate { get; set; }

        public ICollection<Mission> Missions { get; set; }
        public Team Team { get; set; }

        public Consultant()
        {
            Missions = new List<Mission>();
        }
    }
}
