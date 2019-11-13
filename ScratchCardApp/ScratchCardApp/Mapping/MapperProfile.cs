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

        public User MapperUserEntity(UserModel userModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserModel, User>();
            });

            IMapper iMapper = config.CreateMapper();

            var user = iMapper.Map<UserModel, User>(userModel);

            return user;
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