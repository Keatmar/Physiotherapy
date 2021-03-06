﻿using Physiotherapy.Model;
using System.Data.Entity;

namespace Physiotherapy.Context
{
    public class EmailContext : DbContext
    {
        public EmailContext() : base("name = Physiotherapy")
        {
            //Create if not Exists
            // Database.SetInitializer<PersonContext>(new CreateDatabaseIfNotExists<PersonContext>());

            //Disable initializer
            Database.SetInitializer<EmailContext>(null);

            // If Model Change Delete Table
            //Database.SetInitializer<PersonContext>(new DropCreateDatabaseIfModelChanges<PersonContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Person");
            modelBuilder.Entity<EmailVO>().ToTable("Email");
        }

        public virtual DbSet<EmailVO> Emails { get; set; }
    }
}