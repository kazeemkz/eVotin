using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.DAL
{
    public class ElectorateRepository : GenericRepository<Electorate>
    {

        public ElectorateRepository(evContext context)
             : base(context)
          {

          }
    }
}
