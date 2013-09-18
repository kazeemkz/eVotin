using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.DAL
{
    public class PostRepository : GenericRepository<Post>
    {

         public PostRepository(evContext context)
             : base(context)
          {

          }
       }
    }

