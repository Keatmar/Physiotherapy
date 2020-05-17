using Physiotherapy.Model;
using System.Data.Entity;

namespace Physiotherapic.Context
{
    public class PhoneContext : DbContext
    {
        public PhoneContext() : base("name = Physiotherapy")
        {
            //Create if not Exists
            // Database.SetInitializer<PersonContext>(new CreateDatabaseIfNotExists<PersonContext>());

            //Disable initializer
            Database.SetInitializer<PhoneContext>(null);

            // If Model Change Delete Table
            //Database.SetInitializer<PersonContext>(new DropCreateDatabaseIfModelChanges<PersonContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Person");
            modelBuilder.Entity<PhoneVO>().ToTable("Phone");
        }

        public virtual DbSet<PhoneVO> Phones { get; set; }
    }
}