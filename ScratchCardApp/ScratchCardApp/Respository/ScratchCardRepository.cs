using ScratchCardApp.DAL;
using ScratchCardApp.ErrorHandling;
using ScratchCardApp.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Respository
{
    public class ScratchCardRepository
    {
        private readonly ScratchCardContext _context;
        private readonly StackFrame _stackFrame;
        public ScratchCardRepository(ScratchCardContext context)
        {
            this._context = context;
            this._stackFrame = new StackFrame();
        }
        public void AddScratchCard(ScratchCard scratchCardModel)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: AddScratchCard()");
                _context.ScratchCards.Add(scratchCardModel);
                _context.SaveChanges();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "AddScratchCard() Method Executed Successfully");
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public IEnumerable<ScratchCard> GetAllScratchCards()
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetAllScratchCards()");
                var scratchCards = _context.ScratchCards;
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetAllScratchCards() Method Executed Successfully");
                return scratchCards;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public void DeactiveUnusedScratchCards()
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: DeactiveUnusedScratchCards()");
                _context.ScratchCards.
                    Where(x => x.Scratched == false)
                    .ToList()
                    .ForEach(s => s.IsActive = false);

                _context.SaveChanges();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "DeactiveUnusedScratchCards() Method Executed Successfully");
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public IEnumerable<ScratchCard> GetAllUnusedScratchCards()
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetAllUnusedScratchCards()");
                int a = 1, b = 0;
                int c = a / b;
                var unusedScratchCards = _context.ScratchCards.Where(card => card.Scratched == false);
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetAllUnusedScratchCards() Method Executed Successfully");
                return unusedScratchCards;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public bool IsUnusedAndValidScratchCardId(int scratchCardGUID)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: IsUnusedAndValidScratchCardId()");
                var validScratchCard = _context.ScratchCards.Any(card => card.IsActive && card.Scratched == false && card.ScratchCardGUID == scratchCardGUID);
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "IsUnusedAndValidScratchCardId() Method Executed Successfully");
                return validScratchCard;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }
    }
}