namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenceCategories", "UserId", "dbo.Users");
            DropForeignKey("dbo.Expences", "UserId", "dbo.Users");
            DropIndex("dbo.ExpenceCategories", new[] { "UserId" });
            DropIndex("dbo.Expences", new[] { "UserId" });
            AlterColumn("dbo.ExpenceCategories", "UserId", c => c.Int(nullable: false));
            AddForeignKey("dbo.ExpenceCategories", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            CreateIndex("dbo.ExpenceCategories", "UserId");
            DropColumn("dbo.Expences", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expences", "UserId", c => c.Int(nullable: false));
            DropIndex("dbo.ExpenceCategories", new[] { "UserId" });
            DropForeignKey("dbo.ExpenceCategories", "UserId", "dbo.Users");
            AlterColumn("dbo.ExpenceCategories", "UserId", c => c.Int());
            CreateIndex("dbo.Expences", "UserId");
            CreateIndex("dbo.ExpenceCategories", "UserId");
            AddForeignKey("dbo.Expences", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.ExpenceCategories", "UserId", "dbo.Users", "UserId");
        }
    }
}
