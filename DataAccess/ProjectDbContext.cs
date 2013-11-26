using DataAccess.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
            : base("ProjectConnection")
        {

        }


        public ProjectDbContext(string connectionStringName) : base(connectionStringName)
        {
            
        }

        public ProjectDbContext(
            string connectionStringName,
            IDatabaseInitializer<ProjectDbContext> initializer)
            : base(connectionStringName)
        {
            Database.SetInitializer<ProjectDbContext>(initializer);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ExpenceCategoryConfiguration());
            modelBuilder.Configurations.Add(new ExpenceConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
