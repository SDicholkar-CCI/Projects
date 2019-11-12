using ScratchCardApp.DAL;
using ScratchCardApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Respository
{
    public class UserRespository
    {
        private readonly ScratchCardContext _context;

        public UserRespository(ScratchCardContext context)
        {
            this._context = context;
        }
        public User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var allUsers = _context.Users;

            return allUsers;
        }

        public void SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            if (user == null)
            {
                return false;
            }

            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}