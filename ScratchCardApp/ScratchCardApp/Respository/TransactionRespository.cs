using ScratchCardApp.DAL;
using ScratchCardApp.Models;
using ScratchCardApp.Services;
using ScratchCardApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Respository
{
    public class TransactionRespository
    {
        private readonly ScratchCardContext _context;
        public TransactionRespository(ScratchCardContext scratchCardContext)
        {
            this._context = scratchCardContext;
        }
        public Transaction AddTransaction(Transaction transaction)
        {
            try
            {
                var scratchCard = _context.ScratchCards.Where(card => card.ScratchCardGUID == transaction.ScratchCardGUID).FirstOrDefault();
                _context.Transactions.Add(transaction);
                scratchCard.Amount = (scratchCard.Amount - transaction.Amount);
                scratchCard.Scratched = true;
                _context.SaveChanges();

                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<UserTransactionDetails> GetTransactions(int? userId, DateTime? dateOfTransaction)
        {
            List<UserTransactionDetails> userTransactionDetails = new List<UserTransactionDetails>();
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
            return userTransactionDetails;
        }

        public int GetScratchCardBalanceAmount(int scratchCardGuId)
        {
            var scratchCardBalanceAmount = _context.ScratchCards
                                .Where(card => card.ScratchCardGUID == scratchCardGuId)
                                .Select(x => x.Amount)
                                .FirstOrDefault();
            return scratchCardBalanceAmount;

        }
    }
}