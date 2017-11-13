using ContosoConsultancy.DataAccess;
using ContosoConsultancy.Rest.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var idleConsultants = db.Consultants
                .Where(c => !c.Missions.Any(m => m.EndDate == null  || m.EndDate > DateTime.Now));
            var count = idleConsultants.Count();
            return count;
        }

        [Route("topClient")]
        public IEnumerable<CustomerModel> GetTopClient(int? numberOfClients)
        {
            var numberOfClientToTake = numberOfClients ?? 5;
            var topClients = db.Missions
                .Where(m => m.EndDate == null || m.EndDate > DateTime.Now)
                .GroupBy(m => m.Customer)
                .Select(g => new { Customer = g.Key, NumberOfMissions = g.Count() })
                .OrderByDescending(c => c.NumberOfMissions)
                .Take(numberOfClientToTake)
                .ToList();
            return topClients.Select(tc => new CustomerModel {
                Id= tc.Customer.Id,
                Name = tc.Customer.Name,
                NumberOfMissions = tc.NumberOfMissions,
                Country = tc.Customer.Address.Country
            });
        }

        [Route("newestMissions")]
        public IEnumerable<MissionModel> GetNewestMission(int numberOfMissions)
        {
            var newestMissions = db.Missions
                .OrderByDescending(m => m.StartDate)
                .Take(numberOfMissions).ToList();
            return newestMissions.Select(nw => new MissionModel {
                Id = nw.Id,
                Customer = nw.Customer.Name,
                ConsultantFullName = nw.Consultant.Name,
                ConsultantId = nw.Consultant.Id,
                CustomerId = nw.Customer.Id,
                StartDate = nw.StartDate,
                Country = nw.Customer.Address.Country
            });
        }

        [Route("hiredEmployeeByYear")]
        public IEnumerable<KeyValuePair<int, int>> GetHiredEmployeeByYear()
        {
            var hiredConsultantByYear = db.Consultants
                .GroupBy(c => c.HireDate.Year)
                .ToDictionary(g => g.Key,g=>g.Count());
            var min = hiredConsultantByYear.Keys.Min();
            var currentYear = DateTime.Now.Year;
            var years = Enumerable.Range(min, currentYear - min).ToDictionary(i => i, i => 0);

            var result = years
                .Where(y => !hiredConsultantByYear.ContainsKey(y.Key))
                .Union(hiredConsultantByYear)
                .OrderBy(y => y.Key).ToList();

            return result;
        }

    }
}
