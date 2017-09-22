using System;
using System.Collections.Generic;

namespace ContosoConsultancy.Model
{
    public class Mission
    {
        public long Id { get; set; }
        public Consultant Consultant { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Competency> Competencies { get; set; }
    }
}