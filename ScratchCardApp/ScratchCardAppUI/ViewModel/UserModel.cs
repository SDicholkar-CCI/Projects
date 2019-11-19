using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using System.Linq;
using System.Web;

namespace ScratchCardAppUI.ViewModel
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [Required]
        public string ConfirmPassword { get; set; }
        public bool? IsActive { get; set; }
    }
}