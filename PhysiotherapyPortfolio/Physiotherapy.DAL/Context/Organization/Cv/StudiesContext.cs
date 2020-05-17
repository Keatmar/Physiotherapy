using Physiotherapy.Model;
using System.Data.Entity;

namespace Physiotherapic.Context
{
    public class StudiesContext : DbContext
    {
        public StudiesContext() : base("name = Physiotherapy")
        {
            //Create if not Exists
            // Database.SetInitializer<PersonContext>(new CreateDatabaseIfNotExists<PersonContext>());

            //Disable initializer
            Database.SetInitializer<StudiesContext>(null);

            // If Model Change Delete Table
            //Database.SetInitializer<PersonContext>(new DropCreateDatabaseIfModelChanges<PersonContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Cv");
            modelBuilder.Entity<StudiesContext>().ToTable("Studies");
        }

        public virtual DbSet<StudiesVO> Cv { get; set; }
    }
}