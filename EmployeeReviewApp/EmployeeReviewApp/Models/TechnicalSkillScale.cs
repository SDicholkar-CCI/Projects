using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.Models
{
    [Table("TECHNICAL_SKILL_SCALE")]
    public class TechnicalSkillScale
    {
        public int TechnicalSkillScaleId { get; set; }
        public string TechnicalSkillScaleName { get; set; }
    }
}