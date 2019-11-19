using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardAppUI.ViewModel
{
    public class ScratchCardForTransactions
    {
        public int Amount { get; set; }
        public IEnumerable<ScratchCard> scratchCards;
    }
}