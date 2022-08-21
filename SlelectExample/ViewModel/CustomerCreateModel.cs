using Microsoft.AspNetCore.Mvc.Rendering;
using SlelectExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlelectExample.ViewModel
{
    public class CustomerCreateModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
