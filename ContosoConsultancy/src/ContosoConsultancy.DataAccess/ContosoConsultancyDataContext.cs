using ContosoConsultancy.Core.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoConsultancy.DataAccess
{
    public class ContosoConsultancyDataContext : DbContext
    {
        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        public ContosoConsultancyDataContext() : base("ContosoConsultancyDataContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Consultant>()
                .HasOptional<Team>(c => c.Team)
                .WithMany(t => t.Members);

            modelBuilder.Entity<Consultant>()
                .HasMany<Mission>(c => c.Missions)
                .WithOptional(m => m.Consultant);

        }

        
    }
}
