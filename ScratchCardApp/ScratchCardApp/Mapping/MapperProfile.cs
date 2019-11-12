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

        public ScratchCard MapperScratchCardEntity(ScratchCardModel scratchCardModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ScratchCardModel, ScratchCard>();
            });

            IMapper iMapper = config.CreateMapper();

            var scratchCard = iMapper.Map<ScratchCardModel, ScratchCard>(scratchCardModel);

            return scratchCard;
        }

    }
}