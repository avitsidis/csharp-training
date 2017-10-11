using ContosoConsultancy.Core.Model;
using ContosoConsultancy.DataAccess;
using ContosoConsultancy.Rest.Mappers;
using ContosoConsultancy.Rest.Models.Consultants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ContosoConsultancy.Rest.Controllers
{
    public class ConsultantsController : ApiController
    {
        public ConsultantsController(ContosoConsultancyDataContext db)
        {
            this.db = db;
        }
        private ContosoConsultancyDataContext db;

        private ConsultantMapper Map => new ConsultantMapper(Url);

        // GET: api/Consultants
        public IEnumerable<ConsultantModel> GetConsultants([FromUri]SearchConsultantModel search)
        {
            IQueryable<Consultant> consultant = db.Consultants;
            //TODO 1.0 something must be wrong here !
            if (!string.IsNullOrEmpty(search.Name))
            {
                consultant.Where(c => c.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.FirstName))
            {
                consultant.Where(c => c.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }
            //TODO 1.1 must be done on teamName too

            return consultant.Select(Map.ToModel).ToList();
        }

        // GET: api/Consultants/5
        [ResponseType(typeof(ConsultantModel))]
        public async Task<IHttpActionResult> GetConsultant(long id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            return Ok(Map.ToModel(consultant));
        }

        // POST: api/Consultants
        [ResponseType(typeof(ConsultantModel))]
        public async Task<IHttpActionResult> PostConsultant(CreateConsultantModel createConsultant)
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

            return CreatedAtRoute("DefaultApi", new { id = consultant.Id }, Map.ToModel(consultant));
        }

        // DELETE: api/Consultants/5
        [ResponseType(typeof(ConsultantModel))]
        public async Task<IHttpActionResult> DeleteConsultant(long id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            db.Consultants.Remove(consultant);
            await db.SaveChangesAsync();

            return Ok(Map.ToModel(consultant));
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