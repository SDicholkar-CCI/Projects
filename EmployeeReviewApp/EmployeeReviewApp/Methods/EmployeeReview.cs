using EmployeeReviewApp.DAL;
using EmployeeReviewApp.Models;
using EmployeeReviewApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.Methods
{
    public class EmployeeReview : IEmployeeReview
    {
        EmployeeContext employeeContext;
        public EmployeeReview()
        {
            employeeContext = new EmployeeContext();
        }

        public EmployeeDeveloperTechnicalSkill GetDeveloperTechnicalSKillAndScales()
        {
            EmployeeDeveloperTechnicalSkill employeeDeveloperTechnicalSkill = new EmployeeDeveloperTechnicalSkill();
            
            var developerSkills = employeeContext.DeveloperSkills;
            var technicalSkills = employeeContext.TechnicalSkills;
            var developerScales = employeeContext.DeveloperSkillScales;
            var technicalScales = employeeContext.TechnicalSkillScales;

            foreach(var devSkill in developerSkills)
            {
                List<EmployeeDeveloperSkillAndScale> employeeDeveloperSkillAndScales = new List<EmployeeDeveloperSkillAndScale>()
                {
                    new EmployeeDeveloperSkillAndScale{ developerSkill = devSkill, developerSkillScales = developerScales.ToList() }
                };
                if(employeeDeveloperTechnicalSkill.employeeDeveloperSkillAndScales==null)
                {
                    employeeDeveloperTechnicalSkill.employeeDeveloperSkillAndScales = employeeDeveloperSkillAndScales;
                }
                else
                {
                    employeeDeveloperTechnicalSkill.employeeDeveloperSkillAndScales.AddRange(employeeDeveloperSkillAndScales);
                }
                
            }

            foreach (var TechSkill in technicalSkills)
            {
                List<EmployeeTechnicalSkillAndScale> employeeTechnicalSkillAndScales = new List<EmployeeTechnicalSkillAndScale>()
                {
                    new EmployeeTechnicalSkillAndScale { technicalSkill = TechSkill, technicalSkillScales = technicalScales.ToList() }
                };
                if (employeeDeveloperTechnicalSkill.employeeTechnicalSkillAndScales == null)
                {
                    employeeDeveloperTechnicalSkill.employeeTechnicalSkillAndScales = employeeTechnicalSkillAndScales;
                }
                else
                {
                    employeeDeveloperTechnicalSkill.employeeTechnicalSkillAndScales.AddRange(employeeTechnicalSkillAndScales);
                }

            }
            return employeeDeveloperTechnicalSkill;
        }

        public List<UserDeveloperSkill> RatingExistsForEmployee(int userId)
        {         
            var developerRatingResult = employeeContext.UserDeveloperSkills.Include("DeveloperSkill").Include("DeveloperSkillScale").Where(dbUser => dbUser.UserId == userId).ToList();
            return developerRatingResult;
        }

        public int CheckForValidUser(User user)
        {
            var userId = employeeContext.Users.Where(dbUser => dbUser.Name == user.Name && dbUser.Designation == user.Designation).Select(s => s.UserId).FirstOrDefault();
            return userId;
        }

        public void SaveDeveloperSkill(UserDeveloperSkill userDeveloperSkill)
        {
            employeeContext.UserDeveloperSkills.Add(userDeveloperSkill);
            employeeContext.SaveChanges();
        }

        public List<DeveloperSkillDetail> DisplayDeveloperAndTechnicalSkill(int userId)
        {
            var userDeveloerSkill = employeeContext.UserDeveloperSkills.Include("DeveloperSkill").Include("DeveloperSkillScale").Where(dbUser => dbUser.UserId == userId).ToList();
            List<DeveloperSkillDetail> developerSkillDetails = new List<DeveloperSkillDetail>();
            foreach (var obj in userDeveloerSkill)
            {
                DeveloperSkillDetail developerSkillDetailObj = new DeveloperSkillDetail();
                developerSkillDetailObj.Name = obj.User.Name;
                developerSkillDetailObj.Designation = obj.User.Designation;
                developerSkillDetailObj.SkillName = obj.DeveloperSkill.DeveloperSkillName;
                developerSkillDetailObj.ScaleName = obj.DeveloperSkillScale.DeveloperSkillScaleName;
                developerSkillDetailObj.Description = obj.Description;
                developerSkillDetails.Add(developerSkillDetailObj);
            }

            return developerSkillDetails;
        }
    }
}