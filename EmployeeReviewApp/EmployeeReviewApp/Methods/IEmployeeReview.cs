using EmployeeReviewApp.Models;
using EmployeeReviewApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReviewApp.Methods
{
    public interface IEmployeeReview
    {
        bool RatingExistsForEmployee(int userId);
        EmployeeDeveloperTechnicalSkill GetDeveloperTechnicalSKillAndScales();
        int CheckForValidUser(User user);
        void SaveDeveloperSkill(int hdnDeveloperSkill, int btnRadioScaleId, string description, int LoginUserId);
        void SaveTechnicalSkill(int hdnDeveloperSkill, int btnRadioScaleId, string description, int LoginUserId);
        DisplayDeveloperTechnicalSkillAndScale DisplayDeveloperAndTechnicalSkill(int userId);
    }
}
