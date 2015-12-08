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
       [StringLength(50, MinimumLength = 6)]
       public string Password { get; set; }
        public string Department { get; set; }
       public DateTime VotedTime { get; set; }
    //   public string VoterPassword { get; set; }
       public bool Voted { get; set; }

       public string Matric { get; set; }

       //public bool Login { get; set; }

       [Display(Name = "Logged In Attempts After Voting")]
       public int LoggedInAttemptsAfterVoting { get; set; }

     //  int kd { get; set; }
    }
}
