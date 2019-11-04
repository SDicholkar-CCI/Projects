using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.Models
{ 
    [Table("DEVELOPER_SKILL_SCALE")]
    public class DeveloperSkillScale
    {
        public int DeveloperSkillScaleId { get; set; }

        public string DeveloperSkillScaleName { get; set; }
    }
}