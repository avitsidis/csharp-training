using ContosoConsultancy.DataAccess;
using ContosoConsultancy.Rest.Models.Dashboard;
using System.Collections.Generic;
using System.Web.Http;

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
            //TODO 2.1: Number of consultant without a mission
            var count = 0;
            return count;
        }

        [Route("topClient")]
        public IEnumerable<CustomerModel> GetTopClient(int? numberOfClients)
        {
            //TODO 2.2: Top 5 clients
            var result = new List<CustomerModel>();
            return result;
        }

        [Route("newestMissions")]
        public IEnumerable<MissionModel> GetNewestMission(int numberOfMissions)
        {
            //TODO 2.3: 3 Newest missions
            var result = new List<MissionModel>();
            return result;
        }


        [Route("hiredEmployeeByYear")]
        public IEnumerable<KeyValuePair<int, int>> GetHiredEmployeeByYear()
        {
            //TODO 4.1: Number of hired employee each year
            var result = new Dictionary<int, int>();
            return result;
        }

    }
}
