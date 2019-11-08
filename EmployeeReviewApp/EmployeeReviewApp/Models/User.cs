using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.Models
{
    [Table("USER")]
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Text,ErrorMessage = "Cannot Enter Numbers")]
        [DisplayName("First Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Cannot Enter Numbers")]
        public string Designation { get; set; }
    }
}