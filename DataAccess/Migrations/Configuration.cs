using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectDbContext context)
        {
        }
    }
}
