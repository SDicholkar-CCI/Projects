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
            if(TempData["user"]!=null)
            {
                var userTempData = (UserModel)TempData["user"];
                ViewBag.FirstName = userTempData.FirstName;
                ViewBag.LastName = userTempData.LastName;
            }
            ViewBag.showSignOut = true;
            string queryString = "Transaction?userId=" + LoginUserId;
            HttpResponseMessage response = APIClient.webApiClient.GetAsync(queryString).Result;
            var userTransactionDetails = response.Content.ReadAsAsync<IEnumerable<UserTransactionDetails>>().Result;
            TempData["scratchCardId"] = userTransactionDetails.Select(tran => tran.ScratchCardGUID);
            return View(userTransactionDetails);
        }

        public ActionResult Create()
        {
            ViewBag.showSignOut = true;
            ScratchCardForTransactions scratchCardForTransactions = new ScratchCardForTransactions();
            //getting all unused cards
            HttpResponseMessage response = APIClient.webApiClient.GetAsync("ScratchCard/GetAllUnusedScratchCards").Result;
            var scratchCards = response.Content.ReadAsAsync<IEnumerable<ScratchCard>>().Result;
            //getting Used cards
            HttpResponseMessage usedScratchCardResponse = APIClient.webApiClient.GetAsync("ScratchCard/GetScratchCardUsedbyUser/"+LoginUserId).Result;
            var userScratchCardId = usedScratchCardResponse.Content.ReadAsAsync<List<int>>().Result;

            var cardlst = scratchCards.ToList();
            foreach (var id in userScratchCardId)
            {
                cardlst.AddRange(new List<ScratchCard>() { new ScratchCard { ScratchCardGUID = id} });
            }

            scratchCardForTransactions.scratchCards = cardlst;
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