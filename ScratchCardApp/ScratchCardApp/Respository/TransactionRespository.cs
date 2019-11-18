using ScratchCardApp.DAL;
using ScratchCardApp.Models;
using ScratchCardApp.Services;
using ScratchCardApp.ViewModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Respository
{
    public class TransactionRespository
    {
        private readonly ScratchCardContext _context;
        private readonly StackFrame _stackFrame;
        public TransactionRespository(ScratchCardContext scratchCardContext)
        {
            this._context = scratchCardContext;
            this._stackFrame = new StackFrame();
        }
        public Transaction AddTransaction(Transaction transaction)
        {
            Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: AddTransaction() ");
            try
            {
                var scratchCard = _context.ScratchCards.Where(card => card.ScratchCardGUID == transaction.ScratchCardGUID).FirstOrDefault();
                _context.Transactions.Add(transaction);
                scratchCard.Amount = (scratchCard.Amount - transaction.Amount);
                scratchCard.Scratched = true;
                _context.SaveChanges();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "AddTransaction() Method Executed Successfully");
                return transaction;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public IEnumerable<UserTransactionDetails> GetTransactions(int? userId, DateTime? dateOfTransaction)
        {
            Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetTransactions() ");
            List<UserTransactionDetails> userTransactionDetails = new List<UserTransactionDetails>();
            try
            {
                var transactions = (from user in _context.Users
                                    join tran in _context.Transactions
                                    on user.UserId equals tran.UserId
                                    join sCard in _context.ScratchCards
                                    on tran.ScratchCardGUID equals sCard.ScratchCardGUID
                                    let balanceAmount = sCard.Amount
                                    where (user.UserId == userId || userId == null) && (tran.DateofTransaction == dateOfTransaction || dateOfTransaction == null)
                                    select new
                                    {
                                        user.FirstName,
                                        user.LastName,
                                        tran.Amount,
                                        tran.DateofTransaction,
                                        balanceAmount,
                                        sCard.ScratchCardGUID
                                    }
                                        ).ToList();

                foreach (var tran in transactions)
                {
                    UserTransactionDetails transactionDetail = new UserTransactionDetails()
                    {
                        FirstName = tran.FirstName,
                        LastName = tran.LastName,
                        TransactionAmount = tran.Amount,
                        DateofTransaction = tran.DateofTransaction,
                        BalanceAmount = tran.balanceAmount,
                        ScratchCardGUID = tran.ScratchCardGUID
                    };
                    userTransactionDetails.Add(transactionDetail);
                }
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetTransactions() Method Executed Successfully");
                return userTransactionDetails;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public int GetScratchCardBalanceAmount(int scratchCardGuId)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetScratchCardBalanceAmount() ");
                var scratchCardBalanceAmount = _context.ScratchCards
                                    .Where(card => card.ScratchCardGUID == scratchCardGuId)
                                    .Select(x => x.Amount)
                                    .FirstOrDefault();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetScratchCardBalanceAmount() Method Executed Successfully");
                return scratchCardBalanceAmount;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }

        }
    }
}