using AutoMapper;
using ScratchCardApp.Mapping;
using ScratchCardApp.Models;
using ScratchCardApp.Respository;
using ScratchCardApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Services
{
    public class TransactionServices : ITransaction
    {
        private readonly TransactionRespository _transactionRespository;
        private readonly ScratchCardRepository _scratchCardRepository;
        private readonly UserRespository _userRespository;
        private readonly MapperProfile _mapperProfile;
        public TransactionServices(TransactionRespository transactionRespository, MapperProfile mapperProfile, ScratchCardRepository scratchCardRepository, UserRespository userRespository)
        {
            this._transactionRespository = transactionRespository;
            this._mapperProfile = mapperProfile;
            this._scratchCardRepository = scratchCardRepository;
            this._userRespository = userRespository;
        }
        public TransactionModel AddTransaction(TransactionModel transactionModel)
        {
            
            TransactionModel transactionResultModel = new TransactionModel();
            if (transactionModel != null && transactionModel.ScratchCardGUID > 0 && transactionModel.UserId > 0)
            {
                int scratchCardBalanceAmount = _transactionRespository.GetScratchCardBalanceAmount(transactionModel.ScratchCardGUID);
                bool isValidScratchCard = _scratchCardRepository.IsUnusedAndValidScratchCardId(transactionModel.ScratchCardGUID);
                bool IsValidUser = _userRespository.IsValidUser(transactionModel.UserId);
                if (transactionModel.Amount <= scratchCardBalanceAmount && isValidScratchCard && IsValidUser)
                {
                    try
                    {
                        transactionModel.DateofTransaction = DateTime.Now.Date;
                        var config = _mapperProfile.MapperTransactionEntity();
                        IMapper iMapper = config.CreateMapper();
                        var transaction = iMapper.Map<TransactionModel, Transaction>(transactionModel);

                        var transactionsResult = _transactionRespository.AddTransaction(transaction);
                        transactionResultModel = iMapper.Map<Transaction, TransactionModel>(transactionsResult);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                
                
            }
            return transactionResultModel;
        }

        public IEnumerable<UserTransactionDetails> GetTransactions(int? userId, DateTime? dateOfTransaction)
        {
            var transactions = _transactionRespository.GetTransactions(userId, dateOfTransaction);
            return transactions;
        }
    }
}