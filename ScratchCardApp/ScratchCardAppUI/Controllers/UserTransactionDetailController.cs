using ScratchCardAppUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ScratchCardAppUI.Controllers
{
    public class UserTransactionDetailController : Controller
    {
        // GET: UserTransactionDetail
        public ActionResult Index(int userId)
        {
           /// string queryString = "User/LoginDetails/" + login.FirstName + "/" + login.Password;
            //HttpResponseMessage response = APIClient.webApiClient.GetAsync(queryString).Result;
            //var isValidUser = response.Content.ReadAsAsync<bool>().Result;
            return View();
        }
    }
}