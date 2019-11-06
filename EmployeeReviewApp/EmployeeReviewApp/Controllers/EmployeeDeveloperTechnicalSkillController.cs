using EmployeeReviewApp.Methods;
using EmployeeReviewApp.Models;
using EmployeeReviewApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeReviewApp.Controllers
{
    public class EmployeeDeveloperTechnicalSkillController : Controller
    {
        public IEmployeeReview empReview;
        public static EmployeeDeveloperTechnicalSkill employeeDeveloperTechnicalSkill = new EmployeeDeveloperTechnicalSkill();
        public static int LoginUserId { get; set; }
        public static bool IsTechincalSkill { get; set; }
        public EmployeeDeveloperTechnicalSkill employeeSkillResult;
        public EmployeeDeveloperTechnicalSkillController()
        {
            empReview = new EmployeeReview();
            employeeSkillResult = new EmployeeDeveloperTechnicalSkill();
            employeeSkillResult.employeeDeveloperSkillAndScales = new List<EmployeeDeveloperSkillAndScale>();
            employeeSkillResult.employeeTechnicalSkillAndScales = new List<EmployeeTechnicalSkillAndScale>();
        }
        // GET: EmployeeDeveloperTechnicalSkill
        public ActionResult Index(int? hdnCount,int? userId)
        {
            hdnCount = hdnCount == null ? 0 : hdnCount;
            if(userId!=null)
            {
                LoginUserId = userId ?? 0;
            }
            
            ViewBag.hideNextbtn = true;
            if (employeeDeveloperTechnicalSkill != null && employeeDeveloperTechnicalSkill.employeeDeveloperSkillAndScales == null)
            {
                employeeDeveloperTechnicalSkill = empReview.GetDeveloperTechnicalSKillAndScales();
            }
            if (hdnCount < employeeDeveloperTechnicalSkill.employeeDeveloperSkillAndScales.Count && !IsTechincalSkill)
            {
                var singleSkill = employeeDeveloperTechnicalSkill.employeeDeveloperSkillAndScales[hdnCount ?? 0];
                List<EmployeeDeveloperSkillAndScale> employeeSkillScale = new List<EmployeeDeveloperSkillAndScale>()
                {
                    new EmployeeDeveloperSkillAndScale { developerSkill = singleSkill.developerSkill, developerSkillScales = singleSkill.developerSkillScales}
                };
                employeeSkillResult.employeeDeveloperSkillAndScales = employeeSkillScale;

                if(hdnCount == employeeDeveloperTechnicalSkill.employeeDeveloperSkillAndScales.Count-1)
                {
                    IsTechincalSkill = true;
                    hdnCount = 0;
                }
            }
            else
            {
                var singleSkill = employeeDeveloperTechnicalSkill.employeeTechnicalSkillAndScales[hdnCount ?? 0];
                List<EmployeeTechnicalSkillAndScale> employeeSkillScale = new List<EmployeeTechnicalSkillAndScale>()
                {
                    new EmployeeTechnicalSkillAndScale { technicalSkill = singleSkill.technicalSkill, technicalSkillScales = singleSkill.technicalSkillScales}
                };
                employeeSkillResult.employeeTechnicalSkillAndScales = employeeSkillScale;
            }

            if(IsTechincalSkill && hdnCount==0)
            {
                ViewBag.Count = 0;
            }
            else
            {
                ViewBag.Count = hdnCount + 1;
            }
            

            return View(employeeSkillResult);
        }

        [HttpPost]
        public ActionResult SaveDeveloperSkill(int? hdnCount, int hdnDeveloperSkill, int btnRadioScaleId, string description)
        {
            UserDeveloperSkill userDeveloperSkill = new UserDeveloperSkill();
            userDeveloperSkill.DeveloperSkillId = hdnDeveloperSkill;
            userDeveloperSkill.DeveloperSkillScaleId = btnRadioScaleId;
            userDeveloperSkill.Description = description;
            userDeveloperSkill.UserId = LoginUserId;

            //empReview.SaveDeveloperSkill(userDeveloperSkill);

            return RedirectToAction("Index", new { hdnCount = hdnCount});
        }

        public ActionResult DisplayDeveloperAndTechnicalSkill(int userId)
        {
            var result = empReview.DisplayDeveloperAndTechnicalSkill(userId);
            return View(result);
        }
    }
}