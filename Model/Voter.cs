using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Voter
    {
       public int VoterID { get; set; }
       [Required]
       public string IdentityNumber { get; set; }
       [Display(Name = "First Name")]
       public string FirstName { get; set; }
      // [Display(Name = "Last Name")]
       public string LastName { get; set; }
        [Required]
       public string Password { get; set; }
        public string Department { get; set; }
       public DateTime VotedTime { get; set; }
    //   public string VoterPassword { get; set; }
       public bool Voted { get; set; }

       public int kd { get; set; }
    }
}
