using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.Models
{
    [Table("USER")]
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
    }
}