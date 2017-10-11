using ContosoConsultancy.Core.Model;
using ContosoConsultancy.DataAccess;
using ContosoConsultancy.Rest.Mappers;
using ContosoConsultancy.Rest.Models.Customers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ContosoConsultancy.Rest.Controllers
{
    public class CustomersController : ApiController
    {
        private ContosoConsultancyDataContext db;

        private CustomerMapper Map = new CustomerMapper();

        public CustomersController(ContosoConsultancyDataContext db)
        {
            this.db = db;
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            IQueryable<Customer> customers = db.Customers;
            return customers.Select(Map.ToModel).ToList();
        }
    }
}
