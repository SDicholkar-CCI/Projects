using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.ViewModels
{
    public class DeveloperTechnicalSkillScaleDetail
    {
        
        public string Name { get; set; }
        public string Designation { get; set; }
        [DisplayName("Skill Name")]
        public string SkillName { get; set; }
        [DisplayName("Scale Name")]
        public string ScaleName { get; set; }
        public string Description { get; set; }
    }
}