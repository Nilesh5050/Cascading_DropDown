using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SlelectExample.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }

        
        public string StateName { get; set; }


        
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}
