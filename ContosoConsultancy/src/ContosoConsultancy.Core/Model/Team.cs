using System.Collections.Generic;

namespace ContosoConsultancy.Core.Model
{ 
    public class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Consultant Manager { get; set; }
        public ICollection<Consultant> Members { get; set; }

        public Team()
        {
            Members = new List<Consultant>();
        }
        
    }
}