using eVoting.DAL;
using eVoting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace eVoting
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
          //  LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            var migrator = new DbMigrator(new eVoting.DAL.eVConfiguration());
            migrator.Update();  

        }

        public class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                using (var context = new UsersContext())
                {
                    context.UserProfiles.Find(1);
                    //UnitOfWork work = new UnitOfWork();
                   // work.ParticipantRepository.Get();
                }

               // WebSecurity.InitializeDatabaseConnection();
                 //WebSecurity.InitializeDatabaseConnection("evotingDatabase", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                if (!WebSecurity.Initialized)
                    WebSecurity.InitializeDatabaseConnection("evotingDatabase", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
        }




    }
}