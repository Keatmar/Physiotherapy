﻿using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.Context
{
    public class RoleContext : DbContext
    {
        public RoleContext() : base("name = Physiotherapy")
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
            modelBuilder.HasDefaultSchema("Member");
            modelBuilder.Entity<RoleVO>().ToTable("Role");
        }

        public virtual DbSet<RoleVO> Role { get; set; }
        public virtual DbSet<MemberVO> Member { get; set; }
    }
}
