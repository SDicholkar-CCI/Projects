using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.Models
{
    [Table("USER_TECHINCAL_SKILL")]
    public class UserTechincalSkill
    {
        public int UserTechincalSkillId { get; set; }

        public int UserId { get; set; }
        public int TechnicalSkillId { get; set; }
        public int TechnicalSkillScaleId { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual TechnicalSkill TechnicalSkill { get; set; }
        public virtual TechnicalSkillScale TechnicalSkillScale { get; set; }
    }
}