using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoConsultancy.Rest.Models.Consultants
{
    public class CreateConsultantModel
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