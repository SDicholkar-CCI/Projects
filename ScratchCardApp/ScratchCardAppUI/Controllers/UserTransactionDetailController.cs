using ScratchCardAppUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ScratchCardAppUI.Controllers
{
    [Authorize]
    public class UserTransactionDetailController : Controller
    {
        public static int LoginUserId { get; set; }
        // GET: UserTransactionDetail
        public ActionResult Index(int userId = 0)
        {
            if (userId > 0)
            {
                LoginUserId = userId;
            }
            string queryString = "Transaction?userId=" + LoginUserId;
            HttpResponseMessage response = APIClient.webApiClient.GetAsync(queryString).Result;
            var userTransactionDetails = response.Content.ReadAsAsync<IEnumerable<UserTransactionDetails>>().Result;
            return View(userTransactionDetails);
        }

        public ActionResult Create()
        {
            ScratchCardForTransactions scratchCardForTransactions = new ScratchCardForTransactions();
            HttpResponseMessage response = APIClient.webApiClient.GetAsync("ScratchCard/GetAllUnusedScratchCards").Result;
            var scratchCards = response.Content.ReadAsAsync<IEnumerable<ScratchCard>>().Result;
            scratchCardForTransactions.scratchCards = scratchCards;
            return View(scratchCardForTransactions);
        }

        [HttpPost]
        public ActionResult AddTransaction(int amount, int scratchCards)
        {
            Transaction transaction = new Transaction()
            {
                UserId = LoginUserId,
                ScratchCardGUID = scratchCards,
                Amount = amount
            };
            HttpResponseMessage response = APIClient.webApiClient.PostAsJsonAsync("Transaction", transaction).Result;
            var transactions = response.Content.ReadAsAsync<Transaction>().Result;
            return RedirectToAction("Index", new { userId = LoginUserId});
        }

        public ActionResult GetTransaction(int id)
        {
            string queryString = "ScratchCard/GetScratchCard/" + id;
            HttpResponseMessage response = APIClient.webApiClient.GetAsync(queryString).Result;
            var scratchCard = response.Content.ReadAsAsync<ScratchCardModel>().Result;
            return Json(scratchCard, JsonRequestBehavior.AllowGet);
        }
    }
}