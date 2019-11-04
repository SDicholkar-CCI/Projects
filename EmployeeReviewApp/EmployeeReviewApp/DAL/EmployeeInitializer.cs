using EmployeeReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.DAL
{
    public class EmployeeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeeContext>
    {
        protected override void Seed(EmployeeContext context)
        {
            var users = new List<User>()
            {
                new User{ Name="Swapnil",Designation="Developer"},
                new User{ Name="Rahul",Designation="Junior Developer"}
            };

            users.ForEach(user => context.Users.Add(user));
            context.SaveChanges();

            var developerSkills = new List<DeveloperSkill>()
            {
                new DeveloperSkill{ DeveloperSkillName="Coding Skills"},
                new DeveloperSkill{ DeveloperSkillName="TroubleShooting Skills"},
                new DeveloperSkill{ DeveloperSkillName="Quality Assurance"},
                new DeveloperSkill{ DeveloperSkillName="Time Logging"}
            };

            developerSkills.ForEach(devSkills => context.DeveloperSkills.Add(devSkills));
            context.SaveChanges();

            var developerSkillScales = new List<DeveloperSkillScale>()
            {
                new DeveloperSkillScale{ DeveloperSkillScaleName="Outstanding"},
                new DeveloperSkillScale{ DeveloperSkillScaleName="Above Expectations"},
                new DeveloperSkillScale{ DeveloperSkillScaleName="Meets Expectations"},
                new DeveloperSkillScale{ DeveloperSkillScaleName="Needs Improvement"},
                new DeveloperSkillScale{ DeveloperSkillScaleName="Unsatisfactory"}
            };

            developerSkillScales.ForEach(devSkillScale => context.DeveloperSkillScales.Add(devSkillScale));
            context.SaveChanges();

            var technicalSkills = new List<TechnicalSkill>()
            {
                new TechnicalSkill{ TechnicalSkillName="Source Versioning - TFS"},
                new TechnicalSkill{ TechnicalSkillName="Source Versioning - GIT"},
                new TechnicalSkill{ TechnicalSkillName="C#"},
                new TechnicalSkill{ TechnicalSkillName="ASP.NET CORE"},
                new TechnicalSkill{ TechnicalSkillName="Ruby"},
                new TechnicalSkill{ TechnicalSkillName="Angular JS"}
            };

            technicalSkills.ForEach(techSkills => context.TechnicalSkills.Add(techSkills));
            context.SaveChanges();

            var technicalSkillScales = new List<TechnicalSkillScale>()
            {
                new TechnicalSkillScale{ TechnicalSkillScaleName="Beginner"},
                new TechnicalSkillScale{ TechnicalSkillScaleName="Intermediate"},
                new TechnicalSkillScale{ TechnicalSkillScaleName="Proficient"},
                new TechnicalSkillScale{ TechnicalSkillScaleName="Expert"}
            };

            technicalSkillScales.ForEach(techSkillScale => context.TechnicalSkillScales.Add(techSkillScale));
            context.SaveChanges();


        }
    }
}