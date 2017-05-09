namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Season : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeasonLeauges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        SeasonId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seasons", t => t.SeasonId, cascadeDelete: false)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: false)
                .Index(t => t.SeasonId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeasonLeauges", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.SeasonLeauges", "SeasonId", "dbo.Seasons");
            DropIndex("dbo.SeasonLeauges", new[] { "TeamId" });
            DropIndex("dbo.SeasonLeauges", new[] { "SeasonId" });
            DropTable("dbo.Seasons");
            DropTable("dbo.SeasonLeauges");
        }
    }
}
