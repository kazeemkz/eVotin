namespace eVoting.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using eVoting.DAL;
    using Model;
    //using System.Web.Security;
    using WebMatrix.WebData;
    using System.Collections.Generic;

    public class eVConfiguration : DbMigrationsConfiguration<eVoting.DAL.evContext>
    {
        public eVConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }


        protected override void Seed(evContext context)
        {

            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("evotingDatabase", "UserProfile", "UserId", "UserName", autoCreateTables: true);
           // WebSecurity.InitializeDatabaseConnection("evotingDatabase", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("SuperAdmin"))
                Roles.CreateRole("SuperAdmin");

            if (!Roles.RoleExists("Admin"))
                Roles.CreateRole("Admin");

            if (!Roles.RoleExists("InterAdmin"))
                Roles.CreateRole("InterAdmin");

            if (!WebSecurity.UserExists("chair"))
                WebSecurity.CreateUserAndAccount(
                    "chair",
                    "P@ssw0rd");

            if (!WebSecurity.UserExists("kazeem"))
                WebSecurity.CreateUserAndAccount(
                    "kazeem",
                    "P@ssw0rd");

            if (!WebSecurity.UserExists("password"))
                WebSecurity.CreateUserAndAccount(
                    "password",
                    "P@ssw0rd");

            if (!Roles.GetRolesForUser("kazeem").Contains("SuperAdmin"))
                Roles.AddUsersToRoles(new[] { "kazeem" }, new[] { "SuperAdmin" });

            if (!Roles.GetRolesForUser("chair").Contains("InterAdmin"))
                Roles.AddUsersToRoles(new[] { "chair" }, new[] { "InterAdmin" });

            if (!Roles.GetRolesForUser("password").Contains("Admin"))
                Roles.AddUsersToRoles(new[] { "password" }, new[] { "Admin" });

            UnitOfWork work = new UnitOfWork();

            List<Voter> akin = work.VoterRepository.Get(a => a.IdentityNumber == "chair").ToList();
            if (akin.Count() == 0)
            {
                Voter theVoter = new Voter() { Department = "", FirstName = "chair", IdentityNumber = "chair", Voted = false, VotedTime = DateTime.Now, LoggedInAttemptsAfterVoting = 0, LastName = "", Password = "P@ssw0rd" };
                work.VoterRepository.Insert(theVoter);
                work.Save();
            }

            List<Voter> pass = work.VoterRepository.Get(a => a.IdentityNumber == "password").ToList();
            if (pass.Count() == 0)
            {
                Voter theVoter = new Voter() { Department = "", FirstName = "password", IdentityNumber = "password", Voted = false, VotedTime = DateTime.Now, LoggedInAttemptsAfterVoting = 0, LastName = "", Password = "P@ssw0rd" };
                work.VoterRepository.Insert(theVoter);
                work.Save();
            }
            List<Voter> kazee = work.VoterRepository.Get(a => a.IdentityNumber == "password").ToList();
            if (kazee.Count() == 0)
            {
                Voter theVoter = new Voter() { Department = "", FirstName = "kazeem", IdentityNumber = "kazeem", Voted = false, VotedTime = DateTime.Now, LoggedInAttemptsAfterVoting = 0, LastName = "Oyebode1234567", Password = "P@ssw0rd" };
                work.VoterRepository.Insert(theVoter);
                work.Save();
            }



            //  }


        }
    }

}
