using ScratchCardAppUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ScratchCardAppUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.showSignUp = true;
            return View();
        }

        [ActionName("LoginUser")]
        public ActionResult ValidateUserAndLogin(Login login)
        {
            string queryString = "User/LoginDetails/" + login.FirstName + "/" + login.Password;
            HttpResponseMessage response = APIClient.webApiClient.GetAsync(queryString).Result;
            var user = response.Content.ReadAsAsync<UserModel>().Result;
            if (user?.UserId > 0)
            {
                TempData["user"] = user;
                FormsAuthentication.SetAuthCookie(user.UserId.ToString(), false);
                return RedirectToAction("Index", "UserTransactionDetail", new { userId = user.UserId });
            }
            else
            {
                return View("Index");
            }
            
        }

        public ActionResult ClearCookie()
        {
            ViewBag.showSignUp = true;
            FormsAuthentication.SignOut();
            HttpContext.Session.Abandon();
            return View("Index");
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveUser(UserModel userModel)
        {
            HttpResponseMessage existsingUserResponse = APIClient.webApiClient.GetAsync("User/" + userModel.FirstName).Result;
            var user = existsingUserResponse.Content.ReadAsAsync<UserModel>().Result;
            userModel.IsActive = true;

            if (user?.UserId == 0)
            {
                HttpResponseMessage response = APIClient.webApiClient.PostAsJsonAsync("User", userModel).Result;
                var newUser = response.Content.ReadAsAsync<UserModel>().Result;
                if (newUser.UserId > 0 && !ModelState.IsValid)
                {
                    return RedirectToAction("AddUser");
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                ViewBag.Message = "User with First Name: " + userModel.FirstName + " already exists";
                return View("AddUser");
            }
            
        }
    }
}