namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenceCategories",
                c => new
                    {
                        ExpenceCategoryId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenceCategoryId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Expences",
                c => new
                    {
                        ExpenceId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ExpenceCategoryId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Comments = c.String(),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenceId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.ExpenceCategories", t => t.ExpenceCategoryId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ExpenceCategoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Expences", new[] { "ExpenceCategoryId" });
            DropIndex("dbo.Expences", new[] { "UserId" });
            DropIndex("dbo.ExpenceCategories", new[] { "UserId" });
            DropForeignKey("dbo.Expences", "ExpenceCategoryId", "dbo.ExpenceCategories");
            DropForeignKey("dbo.Expences", "UserId", "dbo.Users");
            DropForeignKey("dbo.ExpenceCategories", "UserId", "dbo.Users");
            DropTable("dbo.Expences");
            DropTable("dbo.ExpenceCategories");
        }
    }
}
