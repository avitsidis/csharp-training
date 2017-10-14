using System;
using System.Collections.Generic;

namespace ContosoConsultancy.Core.Model
{
    public class Mission
    {
        public long Id { get; set; }

        public Consultant Consultant { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<Competency> Competencies { get; set; }

        public Mission()
        {
            Competencies = new List<Competency>();
        }
    }
}