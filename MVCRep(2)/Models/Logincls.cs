using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCRep_2_.Models
{
    public class Logincls
    {
        [Required(ErrorMessage ="Enter the Name")]
        public string Uname { get; set; }
        [Required(ErrorMessage ="Enter the Password")]
        public string password { get; set; }
        public string msg { get; set; }
        public string ltype { get; set; }
    }
}