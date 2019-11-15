using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.Models
{
    [Table("USER_DEVELOPER_SKILL")]
    public class UserDeveloperSkill
    {
        public int UserDeveloperSkillId { get; set; }
        public int UserId { get; set; }
        public int DeveloperSkillId { get; set; }
        public int DeveloperSkillScaleId { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual DeveloperSkill DeveloperSkill { get; set; }
        public virtual DeveloperSkillScale DeveloperSkillScale { get; set; }


    }
}