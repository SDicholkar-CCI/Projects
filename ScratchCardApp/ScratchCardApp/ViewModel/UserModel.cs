using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.ViewModel
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}