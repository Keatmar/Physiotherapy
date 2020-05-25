using Physiotherapy.Model;
using System.Data.Entity;

namespace Physiotherapy.Context
{
    public class EducationContext : DbContext
    {
        public EducationContext() : base("name = Physiotherapy")
        {
            //Create if not Exists
            // Database.SetInitializer<PersonContext>(new CreateDatabaseIfNotExists<PersonContext>());

            //Disable initializer
            Database.SetInitializer<EducationContext>(null);

            // If Model Change Delete Table
            //Database.SetInitializer<PersonContext>(new DropCreateDatabaseIfModelChanges<PersonContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Cv");
            modelBuilder.Entity<EducationVO>().ToTable("Education");
            modelBuilder.Entity<EducationVO>().HasKey(s=>s.Id);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<EducationVO> Educations { get; set; }
    }
}