using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SlelectExample.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email is not valid")]
        public string EmailId { get; set; }


        [Required]
        
        
        
        public int CountryID { get; set; }
       
        public virtual Country Country { get; set; }
        


        
        public int StateID { get; set; }
        
        public virtual State State { get; set; }

        
        public int CityID { get; set; }
        
        public virtual City City { get; set; }
    }
}
