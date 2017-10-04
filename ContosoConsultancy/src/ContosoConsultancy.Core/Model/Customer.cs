﻿
namespace ContosoConsultancy.Core.Model
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public Customer()
        {
            Address = new Address();
        }
    }
}
