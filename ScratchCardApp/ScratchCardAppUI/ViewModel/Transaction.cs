using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardAppUI.ViewModel
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int Amount { get; set; }
        public DateTime DateofTransaction { get; set; }
        public int UserId { get; set; }
        public int ScratchCardGUID { get; set; }
    }
}