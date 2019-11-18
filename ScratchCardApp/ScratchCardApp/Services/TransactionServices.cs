using AutoMapper;
using ScratchCardApp.Mapping;
using ScratchCardApp.Models;
using ScratchCardApp.Respository;
using ScratchCardApp.ViewModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly StackFrame _stackFrame;
        public TransactionServices(TransactionRespository transactionRespository, MapperProfile mapperProfile, ScratchCardRepository scratchCardRepository, UserRespository userRespository)
        {
            this._transactionRespository = transactionRespository;
            this._mapperProfile = mapperProfile;
            this._scratchCardRepository = scratchCardRepository;
            this._userRespository = userRespository;
            this._stackFrame = new StackFrame();
        }
        public TransactionModel AddTransaction(TransactionModel transactionModel)
        {
            Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: AddTransaction()");
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
                        Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace + System.Environment.NewLine);
                        throw;
                    }
                }
                
                
            }
            Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "AddTransaction() Method Executed Successfully");
            return transactionResultModel;
        }

        public IEnumerable<UserTransactionDetails> GetTransactions(int? userId, DateTime? dateOfTransaction)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetTransactions()");
                var transactions = _transactionRespository.GetTransactions(userId, dateOfTransaction);
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetTransactions() Method Executed Successfully");
                return transactions;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace + System.Environment.NewLine);
                throw;
            }
        }
    }
}