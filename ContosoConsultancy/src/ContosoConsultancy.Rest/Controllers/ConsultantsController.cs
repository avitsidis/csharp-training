using ContosoConsultancy.Core.Model;
using ContosoConsultancy.DataAccess;
using ContosoConsultancy.Rest.Models.Consultants;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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

        // POST: api/Consultants
        [ResponseType(typeof(Consultant))]
        public async Task<IHttpActionResult> PostConsultant(CreateConsultant createConsultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Consultant consultant = new Consultant
            {
                Name = createConsultant.Name,
                FirstName = createConsultant.FirstName,
                BirthDate = createConsultant.BirthDate,
                HireDate = createConsultant.HireDate,
                DisengagedDate = createConsultant.DisengagedDate
            };

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

    }
}