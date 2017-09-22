using System.Collections.Generic;

namespace ContosoConsultancy.Model
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public List<CustomerContact> Contacts { get; set; }
    }
}
