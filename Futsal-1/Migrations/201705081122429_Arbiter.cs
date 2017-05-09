namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arbiter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arbiters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Matches", "ArbiterId", c => c.Int(nullable: true));
            CreateIndex("dbo.Matches", "ArbiterId");
            AddForeignKey("dbo.Matches", "ArbiterId", "dbo.Arbiters", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "ArbiterId", "dbo.Arbiters");
            DropIndex("dbo.Matches", new[] { "ArbiterId" });
            DropColumn("dbo.Matches", "ArbiterId");
            DropTable("dbo.Arbiters");
        }
    }
}
