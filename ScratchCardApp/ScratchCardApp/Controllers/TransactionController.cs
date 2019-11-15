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
    public class TransactionController : ApiController
    { 
        private readonly ITransaction _transaction;
        public TransactionController(ITransaction transaction)
        {
            this._transaction = transaction;
        }
        
        [Route("api/Transaction/{userId?}/{dateOfTransaction?}")]
        public IHttpActionResult GetTransactions(int? userId, DateTime? dateOfTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = _transaction.GetTransactions(userId, dateOfTransaction);
            if (userId == null && dateOfTransaction ==null)
            {
                return NotFound();
            }

            if(transaction.Count() > 0)
            {
                return Ok(transaction);
            }
            else
            {
                return Ok("No Records Found");
            }

            
        }

        // POST: api/Transaction
        [Route("api/Transaction")]
        public IHttpActionResult AddTransaction(TransactionModel transactionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var transactions = _transaction.AddTransaction(transactionModel);

            if(transactions.TransactionID>0)
            {
                return Ok(transactions);
            }
            else
            {
                return Ok("Invalid Transaction");
            }
            
        }

    }
}