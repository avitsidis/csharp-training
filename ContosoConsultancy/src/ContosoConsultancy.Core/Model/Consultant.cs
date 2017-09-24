using System;
using System.Collections.Generic;

namespace ContosoConsultancy.Core.Model
{
    public class Consultant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DisengagedDate { get; set; }

        public List<Mission> Missions { get; set; }
        public Team Team { get; set; }
    }
}
