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
                new User{ FirstName = "Swapnil", LastName="Dicholkar",Password="Swapnil123", IsActive=true},
                new User{ FirstName = "Rohit", LastName="Naik",Password="Rohit123", IsActive=true}
            };

            users.ForEach(user => context.Users.AddOrUpdate(u => u.FirstName, user));
            context.SaveChanges();
        }
    }
}
