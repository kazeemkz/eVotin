using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Electorate
    {
       public int ElectorateID { get; set; }
       [Display(Name = "User Name")]
       public string UserName { get; set; }
       public string Passw0rd { get; set; }
    }
}
