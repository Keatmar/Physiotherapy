using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.Context
{
    public class MemberContext : DbContext
    {
        public MemberContext() : base("name = Physiotherapy")
        {
            //Create if not Exists
            // Database.SetInitializer<PersonContext>(new CreateDatabaseIfNotExists<PersonContext>());

            //Disable initializer
            Database.SetInitializer<CvContext>(null);

            // If Model Change Delete Table
            //Database.SetInitializer<PersonContext>(new DropCreateDatabaseIfModelChanges<PersonContext>());
        }

        /// <summary>
        /// Context started with Member.Member
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Member");
            modelBuilder.Entity<MemberVO>().ToTable("Member");
        }

      
        public virtual DbSet<MemberVO> Member { get; set; }

        /// <summary>
        /// Member's person
        /// </summary>
        public virtual DbSet<PersonVO> Person { get; set; }

        /// <summary>
        /// Member's addresses
        /// </summary>
        public virtual DbSet<AddressVO> Addresses { get; set; }

        /// <summary>
        /// Member's emails
        /// </summary>
        public virtual DbSet<EmailVO> Emails { get; set; }

        /// <summary>
        /// Member's phones
        /// </summary>
        public virtual DbSet<PhoneVO> Phones { get; set; }

        /// <summary>
        /// Member's CV
        /// </summary>
        public virtual DbSet<CvVO> Cv { get; set; }
    }
}
