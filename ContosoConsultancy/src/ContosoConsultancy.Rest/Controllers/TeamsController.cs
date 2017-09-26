using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ContosoConsultancy.DataAccess;
using System.ComponentModel.DataAnnotations;
using TeamModel = ContosoConsultancy.Rest.Models.Teams.TeamModel;
using CoreTeam = ContosoConsultancy.Core.Model.Team;
using ContosoConsultancy.Rest.Mappers;
using System.Collections.Generic;

namespace ContosoConsultancy.Rest.Controllers
{
    public class TeamsController : ApiController
    {
        private ContosoConsultancyDataContext db = new ContosoConsultancyDataContext();
        private TeamMapper Map => new TeamMapper(Url);

        // GET: api/Teams
        public IEnumerable<TeamModel> GetTeams()
        {
            return db.Teams.Select(Map.ToTeamModel).ToList();
        }
        // GET: api/Teams/5
        [ResponseType(typeof(TeamModel))]
        public async Task<IHttpActionResult> GetTeam(long id)
        {
            var team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(Map.ToTeamModel(team));
        }


        // POST: api/Teams
        [ResponseType(typeof(TeamModel))]
        public async Task<IHttpActionResult> PostTeam([Required][MinLength(1)]string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var team = new CoreTeam { Name = name };
            db.Teams.Add(team);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = team.Id }, Map.ToTeamModel(team));
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(TeamModel))]
        public async Task<IHttpActionResult> DeleteTeam(long id)
        {
            var team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            await db.SaveChangesAsync();

            return Ok(Map.ToTeamModel(team));
        }

        [ResponseType(typeof(TeamModel))]
        [Route("teams/{id}/members")]
        public async Task<IHttpActionResult> PostMember([Required][FromUri]long id, [Required][FromBody]long consultantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var team = await db.Teams.FindAsync(id);
            if (team == null) return NotFound();

            var consultant = await db.Consultants.FindAsync(consultantId);
            if (consultant == null) return NotFound();
            if (team.Members.Any(m => m.Id == consultantId))
                return BadRequest($"Consultant with id {consultantId} already member of team with {id}");

            team.Members.Add(consultant);
            await db.SaveChangesAsync();

            return Ok(Map.ToTeamModel(team));
        }

        [ResponseType(typeof(TeamModel))]
        [Route("teams/{id}/members/{consultantId}")]
        public async Task<IHttpActionResult> DeleteMember([Required][FromUri]long id, [Required][FromUri]long consultantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var team = await db.Teams.FindAsync(id);
            if (team == null) return NotFound();

            var consultant = await db.Consultants.FindAsync(consultantId);
            if (consultant == null) return NotFound();
            if (team.Members.Any(m => m.Id == consultantId))
                return BadRequest($"Consultant with id {consultantId} already member of team with {id}");

            team.Members.Remove(consultant);
            await db.SaveChangesAsync();

            return Ok(Map.ToTeamModel(team));
        }

        [ResponseType(typeof(TeamModel))]
        [Route("teams/{id}/manager/{consultantId}")]
        public async Task<IHttpActionResult> PutManager([Required][FromUri]long id, [Required][FromUri]long consultantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var team = await db.Teams.FindAsync(id);
            if (team == null) return NotFound();

            var consultant = await db.Consultants.FindAsync(consultantId);
            if (consultant == null) return NotFound();
            team.Manager = consultant;

            await db.SaveChangesAsync();

            return Ok(Map.ToTeamModel(team));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamExists(long id)
        {
            return db.Teams.Count(e => e.Id == id) > 0;
        }
    }
}