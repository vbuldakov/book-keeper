using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace Web.App_Start
{
    public class SecurityEnabledDatabaseInitializer : DatabaseInitializer
    {
        protected override void OnDatabaseInitialized()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                    "ProjectConnection",
                    "Users",
                    "UserId",
                    "Email",
                    autoCreateTables: true);
            }
        }
    }
}