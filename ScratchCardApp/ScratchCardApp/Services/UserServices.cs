using AutoMapper;
using ScratchCardApp.DAL;
using ScratchCardApp.Mapping;
using ScratchCardApp.Models;
using ScratchCardApp.Respository;
using ScratchCardApp.ViewModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Services
{
    public class UserServices : IUser
    {
        private readonly UserRespository _userRepository;
        private readonly MapperProfile _mapperProfile;
        private readonly StackFrame _stackFrame;

        public UserServices(UserRespository userRepository, MapperProfile mapperProfile)
        {
            this._userRepository = userRepository;
            this._mapperProfile = mapperProfile;
            this._stackFrame = new StackFrame();
        }

        public User GetUser(int id)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetUser() ");
                User user = new User();
                if (id != 0)
                {
                    user = _userRepository.GetUser(id);
                }
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetUser() Method Executed Successfully");
                return user;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetUser() ");
                var allUsers = _userRepository.GetUsers();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetUser() Method Executed Successfully");
                return allUsers;
            }
            catch (Exception ex)
            {

                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
            
        }

        public UserModel SaveUser(UserModel userModel)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: SaveUser() ");
                var config = _mapperProfile.MapperUserEntity();
                IMapper iMapper = config.CreateMapper();
                var user = iMapper.Map<UserModel, User>(userModel);
                var userEntity = _userRepository.SaveUser(user);
                var userModelResponse = iMapper.Map<User, UserModel>(userEntity);
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "SaveUser() Method Executed Successfully");
                return userModelResponse;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: DeleteUser() ");
                bool success = false;
                if (id != 0)
                {
                    success = _userRepository.DeleteUser(id);
                }
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "DeleteUser() Method Executed Successfully");
                return success;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public bool UpdateUser(UserModel userModel)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: UpdateUser() ");
                if (userModel != null && userModel.UserId != 0)
                {
                    var config = _mapperProfile.MapperUserEntity();
                    IMapper iMapper = config.CreateMapper();
                    var user = iMapper.Map<UserModel, User>(userModel);
                    var success = _userRepository.UpdateUser(user);
                    return success;
                }
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "UpdateUser() Method Executed Successfully");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public int LoginDetails(string firstName, string password)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: LoginDetails() ");
                var userId = _userRepository.LoginDetails(firstName, password);
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "LoginDetails() Method Executed Successfully");
                return userId;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }
    }
}