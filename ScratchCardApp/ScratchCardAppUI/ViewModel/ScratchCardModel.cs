using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardAppUI.ViewModel
{
    public class ScratchCardModel
    {
        public int ScratchCardGUID { get; set; }
        public int Amount { get; set; }
        public DateTime ScratchCardExpiryDate { get; set; }
        public bool Scratched { get; set; }
        public bool IsActive { get; set; }
    }
}