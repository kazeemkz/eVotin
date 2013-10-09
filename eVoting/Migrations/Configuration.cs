//namespace eVoting.Migrations
//{
//    using eVoting.DAL;
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;
//    using System.Web.Security;
//    using WebMatrix.WebData;

//    internal sealed class Configuration : DbMigrationsConfiguration<evContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = true;
//            this.AutomaticMigrationDataLossAllowed = true; 
//        }

//        protected override void Seed(evContext context)
//        {
//            WebSecurity.InitializeDatabaseConnection("evotingDatabase", "UserProfile", "UserId", "UserName", autoCreateTables: true);
//          //  WebSecurity.InitializeDatabaseConnection(connectionStringName: "evotingDatabase", userTableName: "MySchema.User", userIdColumn: "ID", userNameColumn: "Username", autoCreateTables: true);
//            //WebSecurity.InitializeDatabaseConnection(
//            //   "evotingDatabase",
//            //   "UserProfile",
//            //   "UserId",
//            //   "UserName", autoCreateTables: true);

//            if (!Roles.RoleExists("SuperAdmin"))
//                Roles.CreateRole("SuperAdmin");

//            if (!Roles.RoleExists("Admin"))
//                Roles.CreateRole("Admin");

//            if (!Roles.RoleExists("InterAdmin"))
//                Roles.CreateRole("InterAdmin");

//            if (!WebSecurity.UserExists("akinola"))
//                WebSecurity.CreateUserAndAccount(
//                    "akinola",
//                    "P@ssw0rd");

//            if (!WebSecurity.UserExists("kazeem"))
//                WebSecurity.CreateUserAndAccount(
//                    "kazeem",
//                    "P@ssw0rd");

//            if (!WebSecurity.UserExists("password"))
//                WebSecurity.CreateUserAndAccount(
//                    "password",
//                    "P@ssw0rd");

//            if (!Roles.GetRolesForUser("kazeem").Contains("SuperAdmin"))
//                Roles.AddUsersToRoles(new[] { "kazeem" }, new[] { "SuperAdmin" });

//            if (!Roles.GetRolesForUser("akinola").Contains("InterAdmin"))
//                Roles.AddUsersToRoles(new[] { "akinola" }, new[] { "InterAdmin" });

//            if (!Roles.GetRolesForUser("password").Contains("Admin"))
//                Roles.AddUsersToRoles(new[] { "password" }, new[] { "Admin" });
          
//        }
//    }
//}
