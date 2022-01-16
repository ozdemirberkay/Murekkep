using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models.Managers
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<SubSite> SubSites { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Point> Points { get; set; }

        public DbSet<Answer> Answers { get; set; }


        public DbSet<TagOfQuestion> TagOfQuestions { get; set; }

        public DataBaseContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, MurekkepWeb.Migrations.Configuration>());
        }

        public System.Data.Entity.DbSet<MurekkepWeb.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<MurekkepWeb.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<MurekkepWeb.Models.Comment> Comments { get; set; }
    }
}