using System.Collections.Generic;
using System.Data.Entity.Migrations;
using nVision.Api.Models.dataaccess;
using nVision.Api.Models.models;

namespace nVision.Api.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DatabeseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabeseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
/*
            context.Cards.AddOrUpdate(new Card
            {
                Pin = "1478", CardNumber = "123456789",Bloacked = false
            });*/
        }
    }
}
