using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ContosoConsultancy.Core.Model;
using ContosoConsultancy.DataAccess;

namespace ContosoConsultancy.Rest.Controllers
{
    public class MissionsController : ApiController
    {
        private ContosoConsultancyDataContext db = new ContosoConsultancyDataContext();

        // GET: api/Missions
        public IQueryable<Mission> GetMissions()
        {
            return db.Missions;
        }

        // GET: api/Missions/5
        [ResponseType(typeof(Mission))]
        public async Task<IHttpActionResult> GetMission(long id)
        {
            Mission mission = await db.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            return Ok(mission);
        }

        // PUT: api/Missions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMission(long id, Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mission.Id)
            {
                return BadRequest();
            }

            db.Entry(mission).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Missions
        [ResponseType(typeof(Mission))]
        public async Task<IHttpActionResult> PostMission(Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Missions.Add(mission);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mission.Id }, mission);
        }

        // DELETE: api/Missions/5
        [ResponseType(typeof(Mission))]
        public async Task<IHttpActionResult> DeleteMission(long id)
        {
            Mission mission = await db.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            db.Missions.Remove(mission);
            await db.SaveChangesAsync();

            return Ok(mission);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MissionExists(long id)
        {
            return db.Missions.Count(e => e.Id == id) > 0;
        }
    }
}