using ScratchCardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.DAL
{
    public class ScratchCardInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ScratchCardContext>
    {
        protected override void Seed(ScratchCardContext context)
        {
            List<User> users = new List<User>()
            {
                new User{ FirstName = "Swpanil", LastName="Dicholkar", IsActive=true},
                new User{ FirstName = "Rohit", LastName="Naik", IsActive=true}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
        
    }
}