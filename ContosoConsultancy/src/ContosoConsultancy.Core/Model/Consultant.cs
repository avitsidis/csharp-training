using System;
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

        public Consultant(long id, string firstName,string name, DateTime birthdate, DateTime hireDate)
            : this()
        {
            Id = id;
            Name = name;
            FirstName = firstName;
            BirthDate = birthdate;
            HireDate = hireDate;
        }

        public Consultant AddMission(Mission m)
        {
            m.Consultant = this;
            Missions.Add(m);
            return this;
        }
    }
}
