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
    public class TransactionController : ApiController
    { 
        private readonly ITransaction _transaction;
        private readonly StackFrame _stackFrame;
        public TransactionController(ITransaction transaction)
        {
            this._transaction = transaction;
            this._stackFrame = new StackFrame();
            ApplicationError.LogConfigurations();
        }
        
        [Route("api/Transaction/{userId?}/{dateOfTransaction?}")]
        public IHttpActionResult GetTransactions(int? userId, DateTime? dateOfTransaction)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetTransactions()");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var transaction = _transaction.GetTransactions(userId, dateOfTransaction);
                if (userId == null && dateOfTransaction == null)
                {
                    Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetTransactions() Method Executed Successfully");
                    return NotFound();
                }

                if (transaction.Count() > 0)
                {
                    Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetTransactions() Method Executed Successfully");
                    return Ok(transaction);
                }
                else
                {
                    Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetTransactions() Method Executed Successfully");
                    return Ok("No Records Found");
                }
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

        // POST: api/Transaction
        [Route("api/Transaction")]
        public IHttpActionResult AddTransaction(TransactionModel transactionModel)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: AddTransaction()");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var transactions = _transaction.AddTransaction(transactionModel);

                if (transactions.TransactionID > 0)
                {
                    Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "AddTransaction() Method Executed Successfully");
                    return Ok(transactions);
                }
                else
                {
                    Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "AddTransaction() Method Executed Successfully");
                    return Ok("Invalid Transaction");
                }
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

    }
}