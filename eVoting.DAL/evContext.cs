﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SchoolManagement.Model;

namespace eVoting.DAL
{
  public  class evContext : DbContext
    {

      public evContext()
          : base("evotingDatabase") { }

       public DbSet<Post> Posts { get; set; }
       public DbSet<Voter> Voters { get; set; }
       public DbSet<Participant> Participants { get; set; }
       public DbSet<Electorate> Electorates { get; set; }
       public DbSet<Photo> Photos { get; set; }
    }
}
