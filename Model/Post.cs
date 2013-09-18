using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class Post
    {
      public int PostID { get; set; }
      public string PostName { get; set; }
      public List<Participant> TheParticipants { get; set; }
    }
}
