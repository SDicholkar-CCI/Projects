using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.Models
{
    [Table("DEVELOPER_SKILL")]
    public class DeveloperSkill
    {
        public int DeveloperSkillId { get; set; }
        public string DeveloperSkillName { get; set; }
    }
}