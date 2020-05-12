namespace Physiotherapy.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Physiotherapy.DAL;
    using System.Linq;
    using Physiotherapy.Context;

    internal sealed class Configuration : DbMigrationsConfiguration<PhysiotherapyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhysiotherapyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
