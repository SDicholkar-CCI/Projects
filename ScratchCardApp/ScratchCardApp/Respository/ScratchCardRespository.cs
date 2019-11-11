using ScratchCardApp.DAL;
using ScratchCardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Respository
{
    public class ScratchCardRespository
    {
        private readonly ScratchCardContext db;

        public ScratchCardRespository(ScratchCardContext db)
        {
            this.db = db;
        }
        public User GetUser(int id)
        {
            var user = db.Users.Find(id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var allUsers = db.Users;

            return allUsers;
        }

    }
}