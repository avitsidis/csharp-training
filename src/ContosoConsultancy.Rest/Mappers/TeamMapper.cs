using System.Web.Http.Routing;
using System.Linq;
using ContosoConsultancy.Core.Model;
using ContosoConsultancy.Rest.Models.Shared;
using ContosoConsultancy.Rest.Models.Teams;

namespace ContosoConsultancy.Rest.Mappers
{
    public class TeamMapper
    {
        public TeamMapper(UrlHelper url)
        {
            Url = url;
        }

        public UrlHelper Url { get; }

        public TeamModel ToTeamModel(Team team)
        {
            var managerId = team.Manager?.Id;

            return new TeamModel
            {
                Id = team.Id,
                Name = team.Name,
                Manager = ToReference(team.Manager),
                Members = team.Members.Select(m =>ToReference(m)).ToList()
            };
        }

        private ResourceReference ToReference(Consultant consultant)
        {
            if (consultant == null)
            {
                return null;
            }
            return new ResourceReference(consultant.Id, Url.Link("DefaultApi", new {Controller="Consultant", id= consultant.Id }));
        }
    }
}