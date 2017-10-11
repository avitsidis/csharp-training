using ContosoConsultancy.Core.Model;
using ContosoConsultancy.Rest.Models.Customers;

namespace ContosoConsultancy.Rest.Mappers
{
    public class CustomerMapper
    {
        public CustomerModel ToModel(Customer customer)
        {
            var address = customer.Address;
            return new CustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                AddressLine1 = $"{address.Street}, {address.Number}/{address.PostCode}",
                AddressLine2 = $"{address.PostCode} {address.City} ({address.Country})"
            };
        }
    }
}