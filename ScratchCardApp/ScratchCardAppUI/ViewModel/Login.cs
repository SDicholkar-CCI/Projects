using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScratchCardAppUI.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "This field is Required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Password { get; set; }
    }
}