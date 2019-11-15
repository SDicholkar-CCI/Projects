using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.Models
{
    [Table("TECHNICAL_SKILL")]
    public class TechnicalSkill
    {
        public int TechnicalSkillId { get; set; }
        public string TechnicalSkillName { get; set; }
    }
}