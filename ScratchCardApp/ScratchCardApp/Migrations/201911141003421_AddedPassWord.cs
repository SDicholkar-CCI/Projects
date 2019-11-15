namespace ScratchCardApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPassWord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USER", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.USER", "Password");
        }
    }
}
