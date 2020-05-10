using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace forget_Password.Models
{
    public class loginivewmodel
    {
        public int R_id { get; set; }
        public string R_name { get; set; }

        [Required(ErrorMessage ="Please Fill IT")]
        public string R_email { get; set; }

        [Required(ErrorMessage = "Please Fill IT")]
        public string R_password { get; set; }

        [NotMapped]
        [Compare("R_password")]
        public string Confirm_pasword { get; set; }
    }
}