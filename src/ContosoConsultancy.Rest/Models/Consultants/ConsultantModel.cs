using ContosoConsultancy.Rest.Models.Shared;
using System;

namespace ContosoConsultancy.Rest.Models.Consultants
{
    public class ConsultantModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DisengagedDate { get; set; }

        public ResourceReference TeamReference { get; set; }
    }
}