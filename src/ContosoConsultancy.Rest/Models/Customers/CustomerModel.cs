namespace ContosoConsultancy.Rest.Models.Customers
{
    public class CustomerModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; internal set; }
    }
}