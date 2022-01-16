using MurekkepWeb.Models;

namespace MurekkepWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MurekkepWeb.Models.Managers.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MurekkepWeb.Models.Managers.DataBaseContext context)
        {
            //context.Tags.Add(new Tag("Fenerbahce", "Fener ile ilgili"));
            //context.Tags.Add(new Tag("Galatasaray", "gs ile ilgili"));
            //context.Tags.Add(new Tag("Besiktas", "Bjk ile ilgili"));
            //context.Tags.Add(new Tag("Bursa", "Bursa ile ilgili"));
            //context.SaveChanges();

        }
    }
}
