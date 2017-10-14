using System.Collections.Generic;
using System.Linq;

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

        public void AddMember(Consultant c)
        {
            Members.Add(c);
            c.Team = this;
        }

        public void SetManager(Consultant c)
        {
            Members.Add(c);
            Manager = c;
            c.Team = this;
        }

        public void AddAllAsMember(IEnumerable<Consultant> consultants)
        {
            foreach (var consultant in consultants)
            {
                this.AddMember(consultant);
            }
        }
    }
}