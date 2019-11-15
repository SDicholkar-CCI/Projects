using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Models
{
    [Table("TRANSACTION")]
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int Amount { get; set; }
        public DateTime DateofTransaction { get; set; }
        public int UserId { get; set; }
        public int ScratchCardGUID { get; set; }

        public virtual User User { get; set; }
        public virtual ScratchCard ScratchCard { get; set; }
    }
}