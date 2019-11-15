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

        public bool RatingExistsForEmployee(int userId)
        {
            //var developerRatingResult = employeeContext.UserDeveloperSkills.Include("DeveloperSkill").Include("DeveloperSkillScale").Where(dbUser => dbUser.UserId == userId).ToList();
            var developerRatingResult = (from u in employeeContext.Users
                                         join uds in employeeContext.UserDeveloperSkills
                                         on u.UserId equals uds.UserId
                                         join uts in employeeContext.UserTechincalSkills
                                         on u.UserId equals uts.UserId
                                         where u.UserId == userId
                                         select new { userId = u.UserId }).ToList();

            if(developerRatingResult.Count >0 )
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public int CheckForValidUser(User user)
        {
            var userId = employeeContext.Users.Where(dbUser => dbUser.Name == user.Name && dbUser.Designation == user.Designation).Select(s => s.UserId).FirstOrDefault();
            return userId;
        }

        public void SaveDeveloperSkill(int hdnDeveloperSkill, int btnRadioScaleId, string description, int LoginUserId)
        {
            UserDeveloperSkill userDeveloperSkill = new UserDeveloperSkill();
            userDeveloperSkill.DeveloperSkillId = hdnDeveloperSkill;
            userDeveloperSkill.DeveloperSkillScaleId = btnRadioScaleId;
            userDeveloperSkill.Description = description;
            userDeveloperSkill.UserId = LoginUserId;
            if (employeeContext.UserDeveloperSkills.Any(db => db.UserId == userDeveloperSkill.UserId && 
            db.DeveloperSkillId == userDeveloperSkill.DeveloperSkillId && 
            db.DeveloperSkillScaleId == userDeveloperSkill.DeveloperSkillScaleId))
            {
                return;
            }

            var obj = employeeContext.UserDeveloperSkills.SingleOrDefault(db => db.UserId == userDeveloperSkill.UserId &&
            db.DeveloperSkillId == userDeveloperSkill.DeveloperSkillId);
            
           if(obj!=null)
            {
                obj.DeveloperSkillScaleId = userDeveloperSkill.DeveloperSkillScaleId;
                obj.Description = userDeveloperSkill.Description;
            }
            else
            {
                employeeContext.UserDeveloperSkills.Add(userDeveloperSkill);
            }

            employeeContext.SaveChanges();
        }

        public void SaveTechnicalSkill(int hdnDeveloperSkill, int btnRadioScaleId, string description, int LoginUserId)
        {
            UserTechincalSkill userTechincalSkill = new UserTechincalSkill();
            userTechincalSkill.TechnicalSkillId = hdnDeveloperSkill;
            userTechincalSkill.TechnicalSkillScaleId = btnRadioScaleId;
            userTechincalSkill.Description = description;
            userTechincalSkill.UserId = LoginUserId;
            if (employeeContext.UserTechincalSkills.Any(db => db.UserId == userTechincalSkill.UserId &&
             db.TechnicalSkillId == userTechincalSkill.TechnicalSkillId &&
             db.TechnicalSkillScaleId == userTechincalSkill.TechnicalSkillScaleId))
            {
                return;
            }

            var obj = employeeContext.UserTechincalSkills.SingleOrDefault(db => db.UserId == userTechincalSkill.UserId &&
            db.TechnicalSkillId == userTechincalSkill.TechnicalSkillId);

            if (obj != null)
            {
                obj.TechnicalSkillScaleId = userTechincalSkill.TechnicalSkillScaleId;
                obj.Description = userTechincalSkill.Description;
            }
            else
            {
                employeeContext.UserTechincalSkills.Add(userTechincalSkill);
            }

            employeeContext.SaveChanges();
        }
        public DisplayDeveloperTechnicalSkillAndScale DisplayDeveloperAndTechnicalSkill(int userId)
        {
            var userDeveloperSkill = employeeContext.UserDeveloperSkills
                .Include("DeveloperSkill")
                .Include("DeveloperSkillScale")
                .Where(dbUser => dbUser.UserId == userId).ToList();

            List<DeveloperTechnicalSkillScaleDetail> developerSkillDetails = new List<DeveloperTechnicalSkillScaleDetail>();
            foreach (var obj in userDeveloperSkill)
            {
                DeveloperTechnicalSkillScaleDetail developerSkillDetailObj = new DeveloperTechnicalSkillScaleDetail();
                developerSkillDetailObj.Name = obj.User.Name;
                developerSkillDetailObj.Designation = obj.User.Designation;
                developerSkillDetailObj.SkillName = obj.DeveloperSkill.DeveloperSkillName;
                developerSkillDetailObj.ScaleName = obj.DeveloperSkillScale.DeveloperSkillScaleName;
                developerSkillDetailObj.Description = obj.Description;
                developerSkillDetails.Add(developerSkillDetailObj);
            }

            var userTechnicalSkill = employeeContext.UserTechincalSkills
               .Include("TechnicalSkill")
               .Include("TechnicalSkillScale")
               .Where(dbUser => dbUser.UserId == userId).ToList();

            List<DeveloperTechnicalSkillScaleDetail> technicalSkillDetails = new List<DeveloperTechnicalSkillScaleDetail>();
            foreach (var obj in userTechnicalSkill)
            {
                DeveloperTechnicalSkillScaleDetail technicalSkillDetailObj = new DeveloperTechnicalSkillScaleDetail();
                technicalSkillDetailObj.Name = obj.User.Name;
                technicalSkillDetailObj.Designation = obj.User.Designation;
                technicalSkillDetailObj.SkillName = obj.TechnicalSkill.TechnicalSkillName;
                technicalSkillDetailObj.ScaleName = obj.TechnicalSkillScale.TechnicalSkillScaleName;
                technicalSkillDetailObj.Description = obj.Description;
                technicalSkillDetails.Add(technicalSkillDetailObj);
            }

            DisplayDeveloperTechnicalSkillAndScale displayDeveloperTechnicalSkillAndScale = new DisplayDeveloperTechnicalSkillAndScale()
            {
               DeveloperSkillScale = developerSkillDetails,
               TechnicalSkillScale = technicalSkillDetails
            };

            return displayDeveloperTechnicalSkillAndScale;
        }
    }
}