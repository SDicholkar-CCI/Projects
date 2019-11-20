using ScratchCardApp.DAL;
using ScratchCardApp.Models;
using ScratchCardApp.ViewModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ScratchCardApp.Respository
{
    public class UserRespository
    {
        private readonly ScratchCardContext _context;
        private readonly StackFrame _stackFrame;
        public UserRespository(ScratchCardContext context)
        {
            this._context = context;
            this._stackFrame = new StackFrame();
        }
        public User GetUser(string firstName)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetUser() ");
                var user = _context.Users.Where(u => u.FirstName.Equals(firstName)).FirstOrDefault();
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
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: GetUsers() ");
                var allUsers = _context.Users;
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "GetUsers() Method Executed Successfully");
                return allUsers;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public User SaveUser(User user)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: SaveUser() ");
                _context.Users.Add(user);
                _context.SaveChanges();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "SaveUser() Method Executed Successfully");
                return user;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public bool DeleteUser(int id)
        {
            Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: DeleteUser() ");
            User user = _context.Users.Find(id);
            if (user == null)
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "DeleteUser() Method Executed Successfully");
                return false;
            }

            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "DeleteUser() Method Executed Successfully");
                return true;
            }
            catch(Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public bool UpdateUser(User user)
        {
            Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: UpdateUser() ");
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "UpdateUser() Method Executed Successfully");
                return true;
            }
            catch(Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public bool IsValidUser(int userid)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: IsValidUser() ");
                var validUser = _context.Users.Any(user => user.UserId == userid);
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "IsValidUser() Method Executed Successfully");
                return validUser;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public User LoginDetails(string firstName, string password)
        {
            try
            {
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "NameSpace: " + _stackFrame.GetMethod().DeclaringType.Namespace + " Method Name: LoginDetails() ");
                var User = _context.Users.Where(user => user.FirstName == firstName && user.Password == password).FirstOrDefault();
                Log.Information("File Name: " + _stackFrame.GetMethod().DeclaringType.Name + ".cs " + "LoginDetails() Method Executed Successfully");
                return User;
            }
            catch (Exception ex)
            {
                Log.Error("Error Message: " + ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

    }
}