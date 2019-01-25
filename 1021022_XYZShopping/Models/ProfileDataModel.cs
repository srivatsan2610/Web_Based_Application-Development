using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1021022_XYZShopping.Models
{
    public class ProfileDataModel
    {
        [Display(Name = "UserID: ")]
        public string UserID { get; set; }
        [Display(Name = "FirstName: ")]
        public string FirstName { get; set; }
        [Display(Name = "LastName: ")]
        public string LastName { get; set; }
        [Display(Name = "Address: ")]
        public string Address { get; set; }
        [Display(Name = "CCNumber: ")]
        public string CCNumber { get; set; }
        [Display(Name = "Email: ")]
        public string Email { get; set; }
    }
}