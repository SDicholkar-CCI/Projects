namespace EmployeeReviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.USER", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.USER", "Designation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.USER", "Designation", c => c.String());
            AlterColumn("dbo.USER", "Name", c => c.String());
        }
    }
}
