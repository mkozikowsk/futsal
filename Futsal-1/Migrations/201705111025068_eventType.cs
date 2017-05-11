namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MatchEvents", "EventTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.MatchEvents", "EventTypeId");
            AddForeignKey("dbo.MatchEvents", "EventTypeId", "dbo.EventTypes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchEvents", "EventTypeId", "dbo.EventTypes");
            DropIndex("dbo.MatchEvents", new[] { "EventTypeId" });
            DropColumn("dbo.MatchEvents", "EventTypeId");
            DropTable("dbo.EventTypes");
        }
    }
}
