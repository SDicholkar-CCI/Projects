using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScratchCardApp.Mapping;
using ScratchCardApp.Respository;
using ScratchCardApp.ViewModel;

namespace ScratchCardApp.Services
{
    public class ScratchCardServices : IScratchCard
    {
        private readonly ScratchCardRepository _scratchCardRespository;
        private readonly MapperProfile _mapperProfile;
        public ScratchCardServices(ScratchCardRepository scratchCardRepository, MapperProfile mapperProfile)
        {
            this._scratchCardRespository = scratchCardRepository;
            this._mapperProfile = mapperProfile;
        }
        public void AddScratchCard(ScratchCardModel scratchCardModel)
        {
            if (scratchCardModel != null)
            {
                try
                {
                    scratchCardModel.ScratchCardExpiryDate = DateTime.Now;
                    var scratchCard = _mapperProfile.MapperScratchCardEntity(scratchCardModel);
                    _scratchCardRespository.AddScratchCard(scratchCard);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}