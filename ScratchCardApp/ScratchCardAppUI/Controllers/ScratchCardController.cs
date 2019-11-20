using ScratchCardAppUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ScratchCardAppUI.Controllers
{
    public class ScratchCardController : Controller
    {
        // GET: ScratchCard
        [HttpPost]
        public ActionResult SaveScratchCard(int txtScratchCardAmount)
        {
            ScratchCardModel scratchCardModel = new ScratchCardModel();
            scratchCardModel.Amount = txtScratchCardAmount;
            scratchCardModel.IsActive = true;
            scratchCardModel.Scratched = false;
            HttpResponseMessage response = APIClient.webApiClient.PostAsJsonAsync("ScratchCard", scratchCardModel).Result;
            var scratchCardResponse = response.Content.ReadAsAsync<ScratchCardModel>().Result;
            return Json(scratchCardResponse, JsonRequestBehavior.AllowGet);
        }
    }
}