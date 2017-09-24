using ContosoConsultancy.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoConsultancy.DataAccess
{
    public class ContosoConsultancyDataContext : DbContext
    {
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Mission> Missions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
