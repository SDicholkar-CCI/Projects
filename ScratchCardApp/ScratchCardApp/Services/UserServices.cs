using AutoMapper;
using ScratchCardApp.DAL;
using ScratchCardApp.Mapping;
using ScratchCardApp.Models;
using ScratchCardApp.Respository;
using ScratchCardApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Services
{
    public class UserServices : IUser
    {
        private readonly UserRespository _userRepository;
        private readonly MapperProfile _mapperProfile;


        public UserServices(UserRespository userRepository, MapperProfile mapperProfile)
        {
            this._userRepository = userRepository;
            this._mapperProfile = mapperProfile;
        }

        public User GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var allUsers = _userRepository.GetUsers();
            return allUsers;
        }

        public void SaveUser(UserModel userModel)
        {
            var user = _mapperProfile.MapperUserEntity(userModel);
            _userRepository.SaveUser(user);
        }

        public bool DeleteUser(int id)
        {
            var success = _userRepository.DeleteUser(id);

            return success;
        }

        public bool UpdateUser(UserModel userModel)
        {
            var user = _mapperProfile.MapperUserEntity(userModel);
            var success = _userRepository.UpdateUser(user);
            return success;
        }
    }
}