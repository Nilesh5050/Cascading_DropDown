using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SlelectExample.Models
{
    public class Country
    {
        [Key]
        
        public int CountryID { get; set; }

        public string CountryName { get; set; }
        [NotMapped]
        public int StateID { get; set; }
        [NotMapped]
        public int CityID { get; set; }
        [NotMapped]
        public int MyProperty { get; set; }
    }
}
