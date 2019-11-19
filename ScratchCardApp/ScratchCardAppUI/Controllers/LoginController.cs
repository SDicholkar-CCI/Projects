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
            return View();
        }

        [ActionName("LoginUser")]
        public ActionResult ValidateUserAndLogin(Login login)
        {
            string queryString = "User/LoginDetails/" + login.FirstName + "/" + login.Password;
            HttpResponseMessage response = APIClient.webApiClient.GetAsync(queryString).Result;
            var userId = response.Content.ReadAsAsync<int>().Result;
            if (userId > 0)
            {
                FormsAuthentication.SetAuthCookie(userId.ToString(), false);
                return RedirectToAction("Index", "UserTransactionDetail", new { userId = userId });
            }
            else
            {
                return View("Index");
            }
            
        }

        public ActionResult ClearCookie()
        {
            ViewBag.showSignOutButton = false;
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
            HttpResponseMessage response = APIClient.webApiClient.PostAsJsonAsync("User", userModel).Result;
            var user = response.Content.ReadAsAsync<UserModel>().Result;
            if(user.UserId>0)
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("AddUser");
            }
            
        }
    }
}