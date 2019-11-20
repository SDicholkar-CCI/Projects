using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScratchCardAppUI.ViewModel
{
    public class ScratchCardModel
    {
        [Display(Name = "Scratch Card Id")]
        public int ScratchCardGUID { get; set; }
        public int Amount { get; set; }
        public DateTime ScratchCardExpiryDate { get; set; }
        public bool Scratched { get; set; }
        public bool IsActive { get; set; }
    }
}