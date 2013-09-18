using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.DAL
{
  public  class VoterRepository: GenericRepository<Voter>
    {

      public VoterRepository(evContext context)
             : base(context)
          {

          }
    }
}
