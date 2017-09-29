using System;

namespace ContosoConsultancy.Rest.Models.Dashboard
{
    public class MissionModel
    {

        public long Id { get; set; }
        public long ConsultantId { get; set; }
        public long CustomerId { get; set; }
        public string ConsultantFullName { get; set; }
        public string Customer { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }
    }
}