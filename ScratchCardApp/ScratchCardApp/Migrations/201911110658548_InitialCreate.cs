namespace ScratchCardApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SCRATCH_CARD",
                c => new
                    {
                        ScratchCardGUID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ScratchCardExpiryDate = c.DateTime(nullable: false),
                        Scratched = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ScratchCardGUID);
            
            CreateTable(
                "dbo.TRANSACTION",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        DateofTransaction = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        ScratchCardGUID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.SCRATCH_CARD", t => t.ScratchCardGUID, cascadeDelete: true)
                .ForeignKey("dbo.USER", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ScratchCardGUID);
            
            CreateTable(
                "dbo.USER",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TRANSACTION", "UserId", "dbo.USER");
            DropForeignKey("dbo.TRANSACTION", "ScratchCardGUID", "dbo.SCRATCH_CARD");
            DropIndex("dbo.TRANSACTION", new[] { "ScratchCardGUID" });
            DropIndex("dbo.TRANSACTION", new[] { "UserId" });
            DropTable("dbo.USER");
            DropTable("dbo.TRANSACTION");
            DropTable("dbo.SCRATCH_CARD");
        }
    }
}
