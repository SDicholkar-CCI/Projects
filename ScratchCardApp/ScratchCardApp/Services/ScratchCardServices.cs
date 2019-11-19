using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using AutoMapper;
using ScratchCardApp.ErrorHandling;
using ScratchCardApp.Mapping;
using ScratchCardApp.Models;
using ScratchCardApp.Respository;
using ScratchCardApp.ViewModel;
using Serilog;

namespace ScratchCardApp.Services
{
    public class ScratchCardServices : IScratchCard
    {
        private readonly ScratchCardRepository _scratchCardRespository;
        private readonly MapperProfile _mapperProfile;
        private readonly StackFrame _stackFrame;
        public ScratchCardServices(ScratchCardRepository scratchCardRepository, MapperProfile mapperProfile)
        {
            this._scratchCardRespository = scratchCardRepository;
            this._mapperProfile = mapperProfile;
            this._stackFrame = new StackFrame();
        }
        public void AddScratchCard(ScratchCardModel scratchCardModel)
        {
            Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: AddScratchCard() ");
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
                    Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "AddScratchCard() Method Executed Successfully");
                }
                catch (Exception ex)
                {
                    Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                    throw;
                }
            }
        }

        public IEnumerable<ScratchCardModel> GetAllScratchCards()
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetAllScratchCards() ");
                var scratchCards = _scratchCardRespository.GetAllScratchCards();
                List<ScratchCardModel> scratchCardModel = new List<ScratchCardModel>();
                foreach (var scratchCard in scratchCards)
                {
                    var config = _mapperProfile.MapperScratchCardEntity();
                    IMapper iMapper = config.CreateMapper();
                    var model = iMapper.Map<ScratchCard, ScratchCardModel>(scratchCard);
                    scratchCardModel.Add(model);
                }
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetAllScratchCards() Method Executed Successfully");
                return scratchCardModel;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public IEnumerable<ScratchCardModel> GetAllUnusedScratchCards()
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetAllUnusedScratchCards() ");
                var unusedScratchCard = _scratchCardRespository.GetAllUnusedScratchCards();
                List<ScratchCardModel> unusedscratchCardModel = new List<ScratchCardModel>();
                foreach (var scratchCard in unusedScratchCard)
                {
                    var config = _mapperProfile.MapperScratchCardEntity();
                    IMapper iMapper = config.CreateMapper();
                    var model = iMapper.Map<ScratchCard, ScratchCardModel>(scratchCard);
                    unusedscratchCardModel.Add(model);
                }
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetAllUnusedScratchCards() Method Executed Successfully");
                return unusedscratchCardModel;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public ScratchCardModel GetScratchCard(int scratchCardGUID)
        {
            var scratchCard = _scratchCardRespository.GetScratchCard(scratchCardGUID);
            var config = _mapperProfile.MapperScratchCardEntity();
            IMapper iMapper = config.CreateMapper();
            var model = iMapper.Map<ScratchCard, ScratchCardModel>(scratchCard);
            return model;
        }
    }
}