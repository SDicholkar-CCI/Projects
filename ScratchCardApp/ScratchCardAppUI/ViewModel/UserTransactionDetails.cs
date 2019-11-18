using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardAppUI.ViewModel
{
    public class UserTransactionDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TransactionAmount { get; set; }
        public DateTime DateofTransaction { get; set; }
        public int BalanceAmount { get; set; }
        public int ScratchCardGUID { get; set; }
    }
}