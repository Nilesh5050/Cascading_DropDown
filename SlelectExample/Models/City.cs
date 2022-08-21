using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SlelectExample.Models
{
    public class City
    {
        [Key]
        
        public int CityID { get; set; }

        
        
        public string CityName { get; set; }


        
        public int StateID { get; set; }
        public virtual State State { get; set; }

       
    }
}
