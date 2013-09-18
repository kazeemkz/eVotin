using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Photo
    {
        public int PhotoID { get; set; }
        public int ParticipantID { get; set; }
        public byte[] FileData { get; set; }
    }
}
