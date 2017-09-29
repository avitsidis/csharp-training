using ContosoConsultancy.DataAccess;
using ContosoConsultancy.Rest.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace ContosoConsultancy.Rest.Controllers
{
    public class DashboardController : ApiController
    {

        private ContosoConsultancyDataContext db;

        public DashboardController(ContosoConsultancyDataContext db)
        {
            this.db = db;
        }
        
        [Route("idleEmployeeCount")]
        [ResponseType(typeof(int))]
        public IHttpActionResult GetIdleEmployeeCount()
        {
            var count = 0;
            return Ok(count);
        }

        [Route("topClient")]
        [ResponseType(typeof(IEnumerable<string>))]
        public IHttpActionResult GetTopClient(int numberOfClients=3)
        {
            var result = new List<string>();
            return Ok(result);
        }

        [Route("topMissions")]
        [ResponseType(typeof(IEnumerable<MissionModel>))]
        public IHttpActionResult GetNewestMission(int numberOfMissions = 3)
        {
            var result = new List<MissionModel>();
            return Ok(result);
        }


        [Route("avgConsultantContractDurationByYear")]
        [ResponseType(typeof(IEnumerable<KeyValuePair< int,TimeSpan>>))]
        public IHttpActionResult GetAverageConsutlantContractDuration(int numberOfYear)
        {
            var result = new Dictionary<int, TimeSpan>();
            return Ok(result);
        }

    }
}
