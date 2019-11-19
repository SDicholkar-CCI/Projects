using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ScratchCardApp.DAL;
using ScratchCardApp.ErrorHandling;
using ScratchCardApp.Models;
using ScratchCardApp.Services;
using ScratchCardApp.ViewModel;
using Serilog;

namespace ScratchCardApp.Controllers
{
    public class ScratchCardController : ApiController
    {
        private readonly IScratchCard _scratchCard;
        private readonly StackFrame _stackFrame;
        public ScratchCardController(IScratchCard scratchCard)
        {
            this._scratchCard = scratchCard;
            this._stackFrame = new StackFrame();
            ApplicationError.LogConfigurations();
        }

        // GET: api/ScratchCard
        [Route("api/ScratchCard", Name = "GetAllScratchCards")]
        public IHttpActionResult GetScratchCards()
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetScratchCards() ");
                var scratchCards = _scratchCard.GetAllScratchCards();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetScratchCards() Method Executed Successfully");
                return Ok(scratchCards);
            }
            catch (Exception ex)
            {
                Log.Fatal("Error Message: " + ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Stack Trace Below:" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine);
                return InternalServerError();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST: api/ScratchCard
        [HttpPost]
        [ResponseType(typeof(ScratchCard))]
        [Route("api/ScratchCard", Name = "AddScratchCards")]
        public IHttpActionResult PostScratchCard(ScratchCardModel scratchCardModel)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: PostScratchCard() ");
                if (!ModelState.IsValid)
                {
                    Log.Error("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetAllUnusedScratchCards() Error Message: Error in ModelState binding");
                    return BadRequest(ModelState);
                }
                _scratchCard.AddScratchCard(scratchCardModel);
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "PostScratchCard() Method Executed Successfully");
                return RedirectToRoute("GetAllScratchCards", new { id = scratchCardModel.ScratchCardGUID });
            }
            catch (Exception ex)
            {
                Log.Fatal("Error Message: " + ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Stack Trace Below:" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine);
                return InternalServerError();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet]
        [Route("api/ScratchCard/GetAllUnusedScratchCards", Name = "UnusedScratchCards")]
        public IHttpActionResult GetAllUnusedScratchCards()
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetAllUnusedScratchCards() ");
                var unusedScratchCards = _scratchCard.GetAllUnusedScratchCards();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetAllUnusedScratchCards() Method Executed Successfully");
                return Ok(unusedScratchCards);
            }
            catch (Exception ex)
            {
                Log.Fatal("Error Message: " + ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Stack Trace Below:" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine);
                return InternalServerError();
            }
            finally
            {
                Log.CloseAndFlush();
            }


        }

        [HttpGet]
        [Route("api/ScratchCard/GetScratchCard/{scratchCardGUID}", Name = "GetScratchCard")]
        public IHttpActionResult GetScratchCard(int scratchCardGUID)
        {
            var scratchCard = _scratchCard.GetScratchCard(scratchCardGUID);
            return Ok(scratchCard);
        }
    }
}