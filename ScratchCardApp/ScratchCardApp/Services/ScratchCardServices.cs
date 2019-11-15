using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ScratchCardApp.Mapping;
using ScratchCardApp.Models;
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
                    scratchCardModel.ScratchCardExpiryDate = DateTime.Now.AddDays(10).Date;
                    _scratchCardRespository.DeactiveUnusedScratchCards();
                    var config = _mapperProfile.MapperScratchCardEntity();
                    IMapper iMapper = config.CreateMapper();
                    var scratchCard = iMapper.Map<ScratchCardModel, ScratchCard>(scratchCardModel);
                    _scratchCardRespository.AddScratchCard(scratchCard);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<ScratchCardModel> GetAllScratchCards()
        {
            var scratchCards = _scratchCardRespository.GetAllScratchCards();
            List<ScratchCardModel> scratchCardModel = new List<ScratchCardModel>();
            foreach(var scratchCard in scratchCards)
            {
                var config = _mapperProfile.MapperScratchCardEntity();
                IMapper iMapper = config.CreateMapper();
                var model = iMapper.Map<ScratchCard, ScratchCardModel>(scratchCard);
                scratchCardModel.Add(model);
            }

            return scratchCardModel;
        }

        public IEnumerable<ScratchCardModel> GetAllUnusedScratchCards()
        {
            var unusedScratchCard = _scratchCardRespository.GetAllUnusedScratchCards();
            List<ScratchCardModel> unusedscratchCardModel = new List<ScratchCardModel>();
            foreach (var scratchCard in unusedScratchCard)
            {
                var config = _mapperProfile.MapperScratchCardEntity();
                IMapper iMapper = config.CreateMapper();
                var model = iMapper.Map<ScratchCard, ScratchCardModel>(scratchCard);
                unusedscratchCardModel.Add(model);
            }

            return unusedscratchCardModel;
        }
    }
}