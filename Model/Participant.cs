using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
          [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [ConcurrencyCheck]    
        public int Vote { get; set; }

        [ConcurrencyCheck]
        public int Yes { get; set; }

        [ConcurrencyCheck]
        public int No { get; set; }

        public int PostID { get; set; }
        public virtual Post Post { get; set; }


        //Add this to make sure that this is a ConcurrencyCheck field
        //[Timestamp]
       // public byte[] TimeStamp { get; set; } 
        //  public ICollection<>
    }
}
