using ScratchCardApp.Models;
using ScratchCardApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Services
{
    public interface IUser
    {
        IEnumerable<User> GetUsers();

        User GetUser(int id);

        UserModel SaveUser(UserModel user);

        bool DeleteUser(int id);

        bool UpdateUser(UserModel userModel);

        int LoginDetails(string firstName, string password);
    }
}