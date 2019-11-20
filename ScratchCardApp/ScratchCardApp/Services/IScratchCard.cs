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
        ScratchCardModel AddScratchCard(ScratchCardModel scratchCardModel);

        IEnumerable<ScratchCardModel> GetAllScratchCards();

        IEnumerable<ScratchCardModel> GetAllUnusedScratchCards();

        ScratchCardModel GetScratchCard(int scratchCardGUID);

        List<int> GetScratchCardUsedbyUser(int userId);
    }
}
