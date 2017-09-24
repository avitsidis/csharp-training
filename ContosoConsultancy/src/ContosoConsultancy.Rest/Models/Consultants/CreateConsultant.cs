using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContosoConsultancy.Rest.Models.Consultants
{
    public class CreateConsultant
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public DateTime? DisengagedDate { get; set; }
    }
}