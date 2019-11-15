using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using ScratchCardApp.DAL;
using ScratchCardApp.Models;
using ScratchCardApp.Services;
using ScratchCardApp.ViewModel;

namespace ScratchCardApp.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            this._user = user;
        }
        // GET: api/User
        [Route("api/User",Name ="GetAllUsers")]
        public IEnumerable<User> GetUsers()
        {
            var allUsers = _user.GetUsers();
            return allUsers;
        }

        // GET: api/User/5
        [Route("api/User/{id}", Name = "GetUser")]
        public IHttpActionResult GetUser(int id)
        {
            var user = _user.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/User", Name = "UpdateUser")]
        public IHttpActionResult PutUser(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = _user.UpdateUser(userModel);
            if(!success)
            {
                return InternalServerError();
            }

            return RedirectToRoute("GetAllUsers", new { id = userModel.UserId });

        }

        // POST: api/User
        [HttpPost]
        [ResponseType(typeof(User))]
        [Route("api/User", Name = "AddUser")]
        public IHttpActionResult PostUser(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _user.SaveUser(userModel);

            return RedirectToRoute("GetAllUsers", new { id = userModel.UserId});
        }

        // DELETE: api/User/5
        [HttpDelete]
        [ResponseType(typeof(User))]
        [Route("api/User", Name = "DeleteUser")]
        public IHttpActionResult DeleteUser(int id)
        {
            var success = _user.DeleteUser(id);

            if(!success)
            {
                return InternalServerError();
            }
            return RedirectToRoute("GetAllUsers", new { id = id });
        }

        [HttpPost]
        [ResponseType(typeof(User))]
        [Route("api/User/LoginDetails/{firstName}/{password}", Name = "LoginDetails")]
        public IHttpActionResult LoginDetails(string firstName, string password)
        {
            var isValid = _user.LoginDetails(firstName, password);
            return Ok(isValid);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}