using System.Collections.Generic;

namespace ContosoConsultancy.Model
{
    public class Team
    {
        public Consultant Manager { get; set; }
        public List<Consultant> Members { get; set; }
        public string Name { get; set; }
    }
}