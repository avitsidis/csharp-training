using ContosoConsultancy.ContractGenerator.Core.Model;
using ContosoConsultancy.Rest.Client.ContosoConsultancyRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoConsultancy.ContractGenerator.Core
{
    public class ContosoConsultancyServiceProxy
    {
        private readonly IContosoConsultancyRestClient contosoConsultancyRestClient;

        public ContosoConsultancyServiceProxy(IContosoConsultancyRestClient contosoConsultancyRestClient)
        {
            this.contosoConsultancyRestClient = contosoConsultancyRestClient ?? throw new ArgumentNullException(nameof(contosoConsultancyRestClient));
        }

        public List<ConsultantWrapper> FetchConsultants()
        {
            var consultants = contosoConsultancyRestClient.Consultants.GetConsultants();
            return consultants.Select(c => new ConsultantWrapper(c)).ToList();
        }

        public List<CustomerWrapper> FetchCustomers()
        {
            var customers = contosoConsultancyRestClient.Customers.GetAllCustomers();
            return customers.Select(c => new CustomerWrapper(c)).ToList();
        }

        public async Task<List<ConsultantWrapper>> FetchConsultantsAsync()
        {
            var consultants = await contosoConsultancyRestClient.Consultants.GetConsultantsAsync();
            return consultants.Select(c => new ConsultantWrapper(c)).ToList();
        }

        public async Task<List<CustomerWrapper>> FetchCustomersAsync()
        {
            var customers = await contosoConsultancyRestClient.Customers.GetAllCustomersAsync();
            return customers.Select(c => new CustomerWrapper(c)).ToList();
        }
    }
}
