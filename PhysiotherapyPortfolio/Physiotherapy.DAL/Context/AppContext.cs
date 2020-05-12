using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.Context
{
    public class PhysiotherapyContext : DbContext
    {
        public PhysiotherapyContext() : base("name = Physiotherapy")
        {
            //Create if not Exists
            // Database.SetInitializer<PersonContext>(new CreateDatabaseIfNotExists<PersonContext>());

            //Disable initializer
            Database.SetInitializer<PhysiotherapyContext>(null);

            // If Model Change Delete Table
            //Database.SetInitializer<PersonContext>(new DropCreateDatabaseIfModelChanges<PersonContext>());
        }
        public virtual DbSet<MemberVO> Members { get; set; }
        public virtual DbSet<RoleVO> Role { get; set; }
        public virtual DbSet<PersonVO> Persons { get; set; }
        public virtual DbSet<AddressVO> Addresses { get; set; }
        public virtual DbSet<EmailVO> Emails { get; set; }
        public virtual DbSet<PhoneVO> Phones { get; set; }
        public virtual DbSet<CvVO> Cvs { get; set; }
    }
}
