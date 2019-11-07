using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.ViewModels
{
    public class DisplayDeveloperTechnicalSkillAndScale
    {
        public List<DeveloperTechnicalSkillScaleDetail> DeveloperSkillScale { get; set; }
        public List<DeveloperTechnicalSkillScaleDetail> TechnicalSkillScale { get; set; }
    }
}