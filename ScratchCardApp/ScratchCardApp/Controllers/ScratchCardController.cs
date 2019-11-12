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
        public IQueryable<ScratchCard> GetScratchCards()
        {
            return db.ScratchCards;
        }

        // GET: api/ScratchCard/5
        [ResponseType(typeof(ScratchCard))]
        public IHttpActionResult GetScratchCard(int id)
        {
            ScratchCard scratchCard = db.ScratchCards.Find(id);
            if (scratchCard == null)
            {
                return NotFound();
            }

            return Ok(scratchCard);
        }

        // PUT: api/ScratchCard/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutScratchCard(int id, ScratchCard scratchCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scratchCard.ScratchCardGUID)
            {
                return BadRequest();
            }

            db.Entry(scratchCard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScratchCardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ScratchCard
        [HttpPost]
        [ResponseType(typeof(ScratchCard))]
        [Route("api/ScratchCard", Name = "AddScratchCards")]
        public IHttpActionResult PostScratchCard(ScratchCardModel scratchCardModel)
        {
            var date = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _scratchCard.AddScratchCard(scratchCardModel);

            return RedirectToRoute("GetAllScratchCards", new { id = scratchCardModel.ScratchCardGUID} );
        }

        // DELETE: api/ScratchCard/5
        [ResponseType(typeof(ScratchCard))]
        public IHttpActionResult DeleteScratchCard(int id)
        {
            ScratchCard scratchCard = db.ScratchCards.Find(id);
            if (scratchCard == null)
            {
                return NotFound();
            }

            db.ScratchCards.Remove(scratchCard);
            db.SaveChanges();

            return Ok(scratchCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScratchCardExists(int id)
        {
            return db.ScratchCards.Count(e => e.ScratchCardGUID == id) > 0;
        }
    }
}