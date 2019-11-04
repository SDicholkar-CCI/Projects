using EmployeeReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EmployeeReviewApp.DAL
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TechnicalSkill> TechnicalSkills { get; set; }
        public DbSet<DeveloperSkill> DeveloperSkills { get; set; }
        public DbSet<DeveloperSkillScale> DeveloperSkillScales { get; set; }
        public DbSet<TechnicalSkillScale> TechnicalSkillScales { get; set; }
        public DbSet<UserDeveloperSkill> UserDeveloperSkills { get; set; }
        public DbSet<UserTechincalSkill> UserTechincalSkills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}