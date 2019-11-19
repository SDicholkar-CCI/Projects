using AutoMapper;
using ScratchCardApp.Models;
using ScratchCardApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            
        }

        public MapperConfiguration MapperUserEntity()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserModel, User>().ReverseMap();
            });

            return config;
        }

        public MapperConfiguration MapperScratchCardEntity()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ScratchCardModel, ScratchCard>().ReverseMap();
            });

            return config;
        }

        public MapperConfiguration MapperTransactionEntity()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TransactionModel, Transaction>().ReverseMap();
            });

            return config;
        }

    }
}