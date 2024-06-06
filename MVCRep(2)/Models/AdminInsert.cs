using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCRep_2_.Models
{
    public class AdminInsert
    {
        [Required(ErrorMessage ="Enter the name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Enter the Address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Enter the phone number")]
        [RegularExpression(@"^(\d{10})$",ErrorMessage ="Enter valid phone number")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Enter the valid email")]
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [Compare("password",ErrorMessage ="Password Mismatch")]
        public string cpassword { get; set; }
        public string adminmsg { get; set; }
    }
}