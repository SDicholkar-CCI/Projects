using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using ScratchCardApp.DAL;
using ScratchCardApp.ErrorHandling;
using ScratchCardApp.Models;
using ScratchCardApp.Services;
using ScratchCardApp.ViewModel;
using Serilog;

namespace ScratchCardApp.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUser _user;
        private readonly StackFrame _stackFrame;
        public UserController(IUser user)
        {
            this._user = user;
            this._stackFrame = new StackFrame();
            ApplicationError.LogConfigurations();
        }
        // GET: api/User
        [Route("api/User",Name ="GetAllUsers")]
        public IHttpActionResult GetUsers()
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetUsers() ");
                var allUsers = _user.GetUsers();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetUsers() Method Executed Successfully");
                return Ok(allUsers);
            }
            catch (Exception ex)
            {
                Log.Fatal("Error Message: " + ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Stack Trace Below:" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine);
                return InternalServerError();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET: api/User/5
        [Route("api/User/{firstName}", Name = "GetUser")]
        public IHttpActionResult GetUser(string firstName)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetUser() ");
                var user = _user.GetUser(firstName);

                if (user == null)
                {
                    return NotFound();
                }
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetUser() Method Executed Successfully");
                return Ok(user);
            }
            catch (Exception ex)
            {

                Log.Fatal("Error Message: " + ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Stack Trace Below:" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine);
                return InternalServerError();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // PUT: api/User/5
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/User", Name = "UpdateUser")]
        public IHttpActionResult PutUser(UserModel userModel)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: PutUser() ");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var success = _user.UpdateUser(userModel);
                if (!success)
                {
                    return InternalServerError();
                }
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "PutUser() Method Executed Successfully");
                return RedirectToRoute("GetAllUsers", new { id = userModel.UserId });
            }
            catch (Exception ex)
            {
                Log.Fatal("Error Message: " + ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Stack Trace Below:" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine);
                return InternalServerError();
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        // POST: api/User
        [HttpPost]
        [ResponseType(typeof(User))]
        [Route("api/User", Name = "AddUser")]
        public IHttpActionResult PostUser(UserModel userModel)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: PostUser() ");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = _user.SaveUser(userModel);
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "PostUser() Method Executed Successfully");
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Fatal("Error Message: " + ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Stack Trace Below:" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine);
                return InternalServerError();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // DELETE: api/User/5
        [HttpDelete]
        [ResponseType(typeof(User))]
        [Route("api/User", Name = "DeleteUser")]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: DeleteUser() ");
                var success = _user.DeleteUser(id);

                if (!success)
                {
                    return InternalServerError();
                }
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "DeleteUser() Method Executed Successfully");
                return RedirectToRoute("GetAllUsers", new { id = id });
            }
            catch (Exception ex)
            {

                Log.Fatal("Error Message: " + ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Stack Trace Below:" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine);
                return InternalServerError();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet]
        [ResponseType(typeof(User))]
        [Route("api/User/LoginDetails/{firstName}/{password}", Name = "LoginDetails")]
        public IHttpActionResult LoginDetails(string firstName, string password)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: LoginDetails() ");
                var user = _user.LoginDetails(firstName, password);
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "LoginDetails() Method Executed Successfully");
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Fatal("Error Message: " + ex.Message + System.Environment.NewLine + System.Environment.NewLine + "Stack Trace Below:" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine);
                return InternalServerError();
            }
            finally
            {
                Log.CloseAndFlush();
            }
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