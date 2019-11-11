using ScratchCardApp.DAL;
using ScratchCardApp.Models;
using ScratchCardApp.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Services
{
    public class ScratchCardServices : IScratchCard
    {
        private readonly ScratchCardRespository _scratchCardRepository;

        public ScratchCardServices(ScratchCardRespository _scratchCardRepository)
        {
            this._scratchCardRepository = _scratchCardRepository;
        }
        public User GetUser(int id)
        {
            var user = _scratchCardRepository.GetUser(id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var allUsers = _scratchCardRepository.GetUsers();
            return allUsers;
        }
    }
}