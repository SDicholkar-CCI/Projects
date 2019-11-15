using ScratchCardApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchCardApp.Services
{
    public interface ITransaction
    {
        TransactionModel AddTransaction(TransactionModel transactionModel);
        IEnumerable<UserTransactionDetails> GetTransactions(int? userId, DateTime? dateOfTransaction);
    }
}
