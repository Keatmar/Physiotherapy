using Physiotherapy.Model;
using System.Data.Entity;

namespace Physiotherapy.Context
{
    public class AddressContext : DbContext
    {
        public AddressContext() : base("name = Physiotherapy")
        {
            //Create if not Exists
            // Database.SetInitializer<PersonContext>(new CreateDatabaseIfNotExists<PersonContext>());

            //Disable initializer
            Database.SetInitializer<AddressContext>(null);

            // If Model Change Delete Table
            //Database.SetInitializer<PersonContext>(new DropCreateDatabaseIfModelChanges<PersonContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Person");
            modelBuilder.Entity<AddressVO>().ToTable("Address");
        }

        public virtual DbSet<AddressVO> Addresses { get; set; }
    }
}