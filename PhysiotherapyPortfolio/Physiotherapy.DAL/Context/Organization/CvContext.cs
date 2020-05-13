using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.Context
{
    public class CvContext : DbContext
    {
        public CvContext() : base("name = Physiotherapy")
        {
            //Create if not Exists
            // Database.SetInitializer<PersonContext>(new CreateDatabaseIfNotExists<PersonContext>());

            //Disable initializer
            Database.SetInitializer<CvContext>(null);

            // If Model Change Delete Table
            //Database.SetInitializer<PersonContext>(new DropCreateDatabaseIfModelChanges<PersonContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Organization");
            modelBuilder.Entity<CvVO>().ToTable("CV");
        }

        public virtual DbSet<CvVO> Cv { get; set; }
        public virtual DbSet<MemberVO> Member { get; set; }
        public virtual DbSet<PersonVO> Person { get; set; }
        public virtual DbSet<AddressVO> Addresses { get; set; }
        public virtual DbSet<EmailVO> Emails { get; set; }
    }
}
