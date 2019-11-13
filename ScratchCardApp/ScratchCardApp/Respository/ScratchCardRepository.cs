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

        public IEnumerable<ScratchCard> GetAllScratchCards()
        {
            var scratchCards = _context.ScratchCards;
            return scratchCards;
        }

        public void DeactiveUnusedScratchCards()
        {
            _context.ScratchCards.
                Where(x => x.Scratched == false)
                .ToList()
                .ForEach(s => s.IsActive = false);

            _context.SaveChanges();
        }

        public IEnumerable<ScratchCard> GetAllUnusedScratchCards()
        {
            var unusedScratchCards = _context.ScratchCards.Where(card => card.Scratched == false);
            return unusedScratchCards;
        }

        public bool IsUnusedAndValidScratchCardId(int scratchCardGUID)
        {
            var validScratchCard = _context.ScratchCards.Any(card => card.IsActive && card.Scratched == false && card.ScratchCardGUID == scratchCardGUID);
            return validScratchCard;
        }
    }
}