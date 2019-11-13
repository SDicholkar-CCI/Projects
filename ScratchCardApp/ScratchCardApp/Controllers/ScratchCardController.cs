using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ScratchCardApp.DAL;
using ScratchCardApp.Models;
using ScratchCardApp.Services;
using ScratchCardApp.ViewModel;

namespace ScratchCardApp.Controllers
{
    public class ScratchCardController : ApiController
    {
        private ScratchCardContext db = new ScratchCardContext();
        private readonly IScratchCard _scratchCard;
        public ScratchCardController(IScratchCard scratchCard)
        {
            this._scratchCard = scratchCard;
        }

        // GET: api/ScratchCard
        [Route("api/ScratchCard",Name ="GetAllScratchCards")]
        public IEnumerable<ScratchCardModel> GetScratchCards()
        {
            var scratchCards = _scratchCard.GetAllScratchCards();
            return scratchCards;
        }

        // POST: api/ScratchCard
        [HttpPost]
        [ResponseType(typeof(ScratchCard))]
        [Route("api/ScratchCard", Name = "AddScratchCards")]
        public IHttpActionResult PostScratchCard(ScratchCardModel scratchCardModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _scratchCard.AddScratchCard(scratchCardModel);

            return RedirectToRoute("GetAllScratchCards", new { id = scratchCardModel.ScratchCardGUID} );
        }

        [HttpGet]
        [Route("api/ScratchCard/GetAllUnusedScratchCards", Name = "UnusedScratchCards")]
        public IEnumerable<ScratchCardModel> GetAllUnusedScratchCards()
        {
            var unusedScratchCards = _scratchCard.GetAllUnusedScratchCards();
            return unusedScratchCards;

        }

    }
}