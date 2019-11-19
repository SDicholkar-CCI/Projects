using ScratchCardApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchCardApp.Services
{
    public interface IScratchCard
    {
        void AddScratchCard(ScratchCardModel scratchCardModel);

        IEnumerable<ScratchCardModel> GetAllScratchCards();

        IEnumerable<ScratchCardModel> GetAllUnusedScratchCards();

        ScratchCardModel GetScratchCard(int scratchCardGUID);
    }
}
