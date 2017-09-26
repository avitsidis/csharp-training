using ContosoConsultancy.Rest.Models.Shared;
using System.Collections.Generic;

namespace ContosoConsultancy.Rest.Models.Teams
{
    public class TeamModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ResourceReference Manager { get; set; }
        public List<ResourceReference> Members { get; set; }
    }
}