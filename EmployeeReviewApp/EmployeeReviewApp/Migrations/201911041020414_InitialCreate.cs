namespace EmployeeReviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DEVELOPER_SKILL",
                c => new
                    {
                        DeveloperSkillId = c.Int(nullable: false, identity: true),
                        DeveloperSkillName = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperSkillId);
            
            CreateTable(
                "dbo.DEVELOPER_SKILL_SCALE",
                c => new
                    {
                        DeveloperSkillScaleId = c.Int(nullable: false, identity: true),
                        DeveloperSkillScaleName = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperSkillScaleId);
            
            CreateTable(
                "dbo.TECHNICAL_SKILL",
                c => new
                    {
                        TechnicalSkillId = c.Int(nullable: false, identity: true),
                        TechnicalSkillName = c.String(),
                    })
                .PrimaryKey(t => t.TechnicalSkillId);
            
            CreateTable(
                "dbo.TECHNICAL_SKILL_SCALE",
                c => new
                    {
                        TechnicalSkillScaleId = c.Int(nullable: false, identity: true),
                        TechnicalSkillScaleName = c.String(),
                    })
                .PrimaryKey(t => t.TechnicalSkillScaleId);
            
            CreateTable(
                "dbo.USER_DEVELOPER_SKILL",
                c => new
                    {
                        UserDeveloperSkillId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DeveloperSkillId = c.Int(nullable: false),
                        DeveloperSkillScaleId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.UserDeveloperSkillId)
                .ForeignKey("dbo.DEVELOPER_SKILL", t => t.DeveloperSkillId, cascadeDelete: true)
                .ForeignKey("dbo.DEVELOPER_SKILL_SCALE", t => t.DeveloperSkillScaleId, cascadeDelete: true)
                .ForeignKey("dbo.USER", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DeveloperSkillId)
                .Index(t => t.DeveloperSkillScaleId);
            
            CreateTable(
                "dbo.USER",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.USER_TECHINCAL_SKILL",
                c => new
                    {
                        UserTechincalSkillId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TechnicalSkillId = c.Int(nullable: false),
                        TechnicalSkillScaleId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.UserTechincalSkillId)
                .ForeignKey("dbo.TECHNICAL_SKILL", t => t.TechnicalSkillId, cascadeDelete: true)
                .ForeignKey("dbo.TECHNICAL_SKILL_SCALE", t => t.TechnicalSkillScaleId, cascadeDelete: true)
                .ForeignKey("dbo.USER", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TechnicalSkillId)
                .Index(t => t.TechnicalSkillScaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.USER_TECHINCAL_SKILL", "UserId", "dbo.USER");
            DropForeignKey("dbo.USER_TECHINCAL_SKILL", "TechnicalSkillScaleId", "dbo.TECHNICAL_SKILL_SCALE");
            DropForeignKey("dbo.USER_TECHINCAL_SKILL", "TechnicalSkillId", "dbo.TECHNICAL_SKILL");
            DropForeignKey("dbo.USER_DEVELOPER_SKILL", "UserId", "dbo.USER");
            DropForeignKey("dbo.USER_DEVELOPER_SKILL", "DeveloperSkillScaleId", "dbo.DEVELOPER_SKILL_SCALE");
            DropForeignKey("dbo.USER_DEVELOPER_SKILL", "DeveloperSkillId", "dbo.DEVELOPER_SKILL");
            DropIndex("dbo.USER_TECHINCAL_SKILL", new[] { "TechnicalSkillScaleId" });
            DropIndex("dbo.USER_TECHINCAL_SKILL", new[] { "TechnicalSkillId" });
            DropIndex("dbo.USER_TECHINCAL_SKILL", new[] { "UserId" });
            DropIndex("dbo.USER_DEVELOPER_SKILL", new[] { "DeveloperSkillScaleId" });
            DropIndex("dbo.USER_DEVELOPER_SKILL", new[] { "DeveloperSkillId" });
            DropIndex("dbo.USER_DEVELOPER_SKILL", new[] { "UserId" });
            DropTable("dbo.USER_TECHINCAL_SKILL");
            DropTable("dbo.USER");
            DropTable("dbo.USER_DEVELOPER_SKILL");
            DropTable("dbo.TECHNICAL_SKILL_SCALE");
            DropTable("dbo.TECHNICAL_SKILL");
            DropTable("dbo.DEVELOPER_SKILL_SCALE");
            DropTable("dbo.DEVELOPER_SKILL");
        }
    }
}
