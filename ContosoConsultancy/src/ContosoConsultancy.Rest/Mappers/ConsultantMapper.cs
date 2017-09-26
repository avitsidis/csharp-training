using ContosoConsultancy.Core.Model;
using ContosoConsultancy.Rest.Models.Consultants;
using ContosoConsultancy.Rest.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace ContosoConsultancy.Rest.Mappers
{
    public class ConsultantMapper
    {
        public ConsultantMapper(UrlHelper url)
        {
            Url = url;
        }

        public UrlHelper Url { get; }

        public ConsultantModel ToModel(Consultant consultant)
        {
            var team = consultant.Team;
            ResourceReference teamref = null;
            if(consultant.Team != null)
            {
                var routeData = new { Controller = "Team", id = consultant.Id };
                teamref = new ResourceReference(team.Id, Url.Link("DefaultApi", routeData));
            }
            return new ConsultantModel
            {
                Id = consultant.Id,
                BirthDate = consultant.BirthDate,
                DisengagedDate = consultant.DisengagedDate,
                FirstName = consultant.FirstName,
                HireDate = consultant.HireDate,
                Name = consultant.Name,
                TeamReference = teamref
            };
        }
    }
}