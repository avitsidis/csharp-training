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
        public int GetIdleEmployeeCount()
        {
            var count = 0;
            return count;
        }

        [Route("topClient")]
        public IEnumerable<CustomerModel> GetTopClient(int? numberOfClients)
        {
            var result = new List<CustomerModel>();
            return result;
        }

        [Route("newestMissions")]
        public IEnumerable<MissionModel> GetNewestMission(int numberOfMissions)
        {
            var result = new List<MissionModel>();
            return result;
        }


        [Route("hiredEmployeeByYear")]
        public IEnumerable<KeyValuePair<int, int>> GetHiredEmployeeByYear()
        {
            var result = new Dictionary<int, int>();
            return result;
        }

    }
}
