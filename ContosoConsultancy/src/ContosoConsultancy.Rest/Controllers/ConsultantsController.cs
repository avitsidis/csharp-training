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
    public class ConsultantsController : ApiController
    {
        private ContosoConsultancyDataContext db = new ContosoConsultancyDataContext();

        // GET: api/Consultants
        public IQueryable<Consultant> GetConsultants()
        {
            return db.Consultants;
        }

        // GET: api/Consultants/5
        [ResponseType(typeof(Consultant))]
        public async Task<IHttpActionResult> GetConsultant(long id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            return Ok(consultant);
        }

        // PUT: api/Consultants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConsultant(long id, Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultant.Id)
            {
                return BadRequest();
            }

            db.Entry(consultant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantExists(id))
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

        // POST: api/Consultants
        [ResponseType(typeof(Consultant))]
        public async Task<IHttpActionResult> PostConsultant(Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consultants.Add(consultant);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = consultant.Id }, consultant);
        }

        // DELETE: api/Consultants/5
        [ResponseType(typeof(Consultant))]
        public async Task<IHttpActionResult> DeleteConsultant(long id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            db.Consultants.Remove(consultant);
            await db.SaveChangesAsync();

            return Ok(consultant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultantExists(long id)
        {
            return db.Consultants.Count(e => e.Id == id) > 0;
        }
    }
}