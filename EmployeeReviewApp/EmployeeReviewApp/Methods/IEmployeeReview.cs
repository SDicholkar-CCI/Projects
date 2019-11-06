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
        List<UserDeveloperSkill> RatingExistsForEmployee(int userId);
        EmployeeDeveloperTechnicalSkill GetDeveloperTechnicalSKillAndScales();
        int CheckForValidUser(User user);
        void SaveDeveloperSkill(UserDeveloperSkill userDeveloperSkill);
        List<DeveloperSkillDetail> DisplayDeveloperAndTechnicalSkill(int userId);
    }
}
