namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatchEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        EventTime = c.DateTime(nullable: false),
                        PlayerId = c.Int(nullable: true),
                        MatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: false)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .Index(t => t.PlayerId)
                .Index(t => t.MatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchEvents", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MatchEvents", "MatchId", "dbo.Matches");
            DropIndex("dbo.MatchEvents", new[] { "MatchId" });
            DropIndex("dbo.MatchEvents", new[] { "PlayerId" });
            DropTable("dbo.MatchEvents");
        }
    }
}
