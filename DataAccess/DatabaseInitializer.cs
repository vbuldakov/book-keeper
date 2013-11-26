using DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class DatabaseInitializer : IDatabaseInitializer<ProjectDbContext>
    {
        public void InitializeDatabase(ProjectDbContext context)
        {
            var createDb = new MigrateDatabaseToLatestVersion<ProjectDbContext, Configuration>();

            createDb.InitializeDatabase(context);

            OnDatabaseInitialized();
        }

        protected virtual void OnDatabaseInitialized()
        {
        }
    }

}
