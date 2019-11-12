using ScratchCardApp.DAL;
using ScratchCardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Respository
{
    public class ScratchCardRepository
    {
        private readonly ScratchCardContext _context;
        public ScratchCardRepository(ScratchCardContext context)
        {
            this._context = context;
        }
        public void AddScratchCard(ScratchCard scratchCardModel)
        {
            _context.ScratchCards.Add(scratchCardModel);
            _context.SaveChanges();
        }
    }
}