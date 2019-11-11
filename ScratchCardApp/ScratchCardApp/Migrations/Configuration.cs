namespace ScratchCardApp.Migrations
{
    using ScratchCardApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ScratchCardApp.DAL.ScratchCardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ScratchCardApp.DAL.ScratchCardContext";
        }

        protected override void Seed(ScratchCardApp.DAL.ScratchCardContext context)
        {
            List<User> users = new List<User>()
            {
                new User{ FirstName = "Swpanil", LastName="Dicholkar", IsActive=true},
                new User{ FirstName = "Rohit", LastName="Naik", IsActive=true}
            };

            users.ForEach(user => context.Users.AddOrUpdate(u => u.UserId, user));
            context.SaveChanges();
        }
    }
}
