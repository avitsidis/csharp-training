using ContosoConsultancy.Rest.Client.ContosoConsultancyRest.Models;

namespace ContosoConsultancy.Administration.UI.Model
{
    public class CustomerWrapper
    {
        public CustomerWrapper(ContosoConsultancyRestModelsCustomersCustomerModel customer)
        {
            Customer = customer;
        }

        public ContosoConsultancyRestModelsCustomersCustomerModel Customer { get; }

        public override string ToString()
        {
            return Customer.Name;
        }
    }
}
