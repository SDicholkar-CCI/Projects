using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Models
{
    [Table("SCRATCH_CARD")]
    public class ScratchCard
    {
        [Key]
        public int ScratchCardGUID { get; set; }
        public int Amount { get; set; }
        public DateTime ScratchCardExpiryDate { get; set; }
        public bool Scratched { get; set; }
        public bool IsActive { get; set; }
    }
}