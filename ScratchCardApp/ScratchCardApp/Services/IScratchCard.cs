using ScratchCardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Services
{
    public interface IScratchCard
    {
        IEnumerable<User> GetUsers();

        User GetUser(int id);
    }
}