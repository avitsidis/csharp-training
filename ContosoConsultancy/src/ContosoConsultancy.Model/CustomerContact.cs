namespace ContosoConsultancy.Model
{
    public class CustomerContact
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public Customer Company { get; set; }
    }
}