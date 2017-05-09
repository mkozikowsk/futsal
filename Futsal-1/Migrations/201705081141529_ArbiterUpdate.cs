namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArbiterUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "ArbiterId", "dbo.Arbiters");
            DropIndex("dbo.Matches", new[] { "ArbiterId" });
            AlterColumn("dbo.Matches", "ArbiterId", c => c.Int());
            CreateIndex("dbo.Matches", "ArbiterId");
            AddForeignKey("dbo.Matches", "ArbiterId", "dbo.Arbiters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "ArbiterId", "dbo.Arbiters");
            DropIndex("dbo.Matches", new[] { "ArbiterId" });
            AlterColumn("dbo.Matches", "ArbiterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "ArbiterId");
            AddForeignKey("dbo.Matches", "ArbiterId", "dbo.Arbiters", "Id", cascadeDelete: true);
        }
    }
}
