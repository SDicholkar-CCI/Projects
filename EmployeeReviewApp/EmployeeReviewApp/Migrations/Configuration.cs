namespace EmployeeReviewApp.Migrations
{
    using EmployeeReviewApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeReviewApp.DAL.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EmployeeReviewApp.DAL.EmployeeContext";
        }

        protected override void Seed(EmployeeReviewApp.DAL.EmployeeContext context)
        {
            var users = new List<User>()
            {
                new User{ Name="Swapnil",Designation="Developer"},
                new User{ Name="Rahul",Designation="Junior Developer"},
                new User{ Name="Sam",Designation="Team Lead"}
            };

            users.ForEach(user => context.Users.AddOrUpdate(u => u.UserId, user));
            context.SaveChanges();

            var developerSkills = new List<DeveloperSkill>()
            {
                new DeveloperSkill{ DeveloperSkillName="Coding Skills"},
                new DeveloperSkill{ DeveloperSkillName="TroubleShooting Skills"},
                new DeveloperSkill{ DeveloperSkillName="Quality Assurance"},
                new DeveloperSkill{ DeveloperSkillName="Time Logging"}
            };

            developerSkills.ForEach(devSkills => context.DeveloperSkills.AddOrUpdate(d => d.DeveloperSkillId,devSkills));
            context.SaveChanges();

            var developerSkillScales = new List<DeveloperSkillScale>()
            {
                new DeveloperSkillScale{ DeveloperSkillScaleName="Outstanding"},
                new DeveloperSkillScale{ DeveloperSkillScaleName="Above Expectations"},
                new DeveloperSkillScale{ DeveloperSkillScaleName="Meets Expectations"},
                new DeveloperSkillScale{ DeveloperSkillScaleName="Needs Improvement"},
                new DeveloperSkillScale{ DeveloperSkillScaleName="Unsatisfactory"}
            };

            developerSkillScales.ForEach(devSkillScale => context.DeveloperSkillScales.AddOrUpdate(d => d.DeveloperSkillScaleId,devSkillScale));
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

            technicalSkills.ForEach(techSkills => context.TechnicalSkills.AddOrUpdate(t => t.TechnicalSkillId,techSkills));
            context.SaveChanges();

            var technicalSkillScales = new List<TechnicalSkillScale>()
            {
                new TechnicalSkillScale{ TechnicalSkillScaleName="Beginner"},
                new TechnicalSkillScale{ TechnicalSkillScaleName="Intermediate"},
                new TechnicalSkillScale{ TechnicalSkillScaleName="Proficient"},
                new TechnicalSkillScale{ TechnicalSkillScaleName="Expert"}
            };

            technicalSkillScales.ForEach(techSkillScale => context.TechnicalSkillScales.AddOrUpdate(t => t.TechnicalSkillScaleId,techSkillScale));
            context.SaveChanges();
        }
    }
}
