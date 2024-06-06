using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCRep_2_.Models
{
    public class UserInsert
    {
        [Required(ErrorMessage = "Enter the name")]
        public string name { get; set; }
        [Range(18,60,ErrorMessage ="Enter the valid age")]
        public int age { get; set; }
        [Required(ErrorMessage = "Enter the Address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Enter the valid email")]
        public string email { get; set; }
        public string photo { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [Compare("password",ErrorMessage ="Password Mismatch")]
        public string cpassword { get; set; }
        public string usermsg { get; set; }
    }
}