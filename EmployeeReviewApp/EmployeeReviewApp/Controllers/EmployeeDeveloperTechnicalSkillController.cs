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
    [Authorize]
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
            ViewBag.showSignOutButton = true;
            hdnCount = hdnCount == null ? 0 : hdnCount;
            if(userId!=null)
            {
                LoginUserId = userId ?? 0;
            }
            
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

                }
                else
                {
                    if (!IsTechincalSkill)
                    {
                        hdnCount = 0;
                        IsTechincalSkill = true;
                    }
                    if (hdnCount < employeeDeveloperTechnicalSkill.employeeTechnicalSkillAndScales.Count)
                    {
                        var singleSkill = employeeDeveloperTechnicalSkill.employeeTechnicalSkillAndScales[hdnCount ?? 0];
                        List<EmployeeTechnicalSkillAndScale> employeeSkillScale = new List<EmployeeTechnicalSkillAndScale>()
                    {
                        new EmployeeTechnicalSkillAndScale { technicalSkill = singleSkill.technicalSkill, technicalSkillScales = singleSkill.technicalSkillScales}
                    };
                        employeeSkillResult.employeeTechnicalSkillAndScales = employeeSkillScale;
                    }
                }

                if (employeeSkillResult.employeeTechnicalSkillAndScales.Count == 0 && employeeSkillResult.employeeDeveloperSkillAndScales.Count == 0)
                {
                    return RedirectToAction("DisplayDeveloperAndTechnicalSkill", new { userId = LoginUserId });
                }
            
            ViewBag.Count = hdnCount + 1;
            

            return View(employeeSkillResult);
        }

        [HttpPost]
        public ActionResult SaveDeveloperSkill(int? hdnCount, int hdnDeveloperSkill, int btnRadioScaleId, string description)
        {
            if (!IsTechincalSkill)
            {
                empReview.SaveDeveloperSkill(hdnDeveloperSkill ,btnRadioScaleId ,description, LoginUserId);
            }
            else
            {
                empReview.SaveTechnicalSkill(hdnDeveloperSkill, btnRadioScaleId, description, LoginUserId);
            }

            return RedirectToAction("Index", new { hdnCount = hdnCount});
        }

        public ActionResult DisplayDeveloperAndTechnicalSkill(int userId)
        {
            ViewBag.showSignOutButton = true;
            var result = empReview.DisplayDeveloperAndTechnicalSkill(userId);
            return View(result);
        }
    }
}