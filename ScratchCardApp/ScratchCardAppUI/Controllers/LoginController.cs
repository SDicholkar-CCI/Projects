using ScratchCardAppUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

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
            string queryString = "User/LoginDetails?firstName=" + login.FirstName + "&password=" + login.Password;
            HttpResponseMessage response = APIClient.webApiClient.GetAsync("User").Result;
            return View();
        }
    }
}