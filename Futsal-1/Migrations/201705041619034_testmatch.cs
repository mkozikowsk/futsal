namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testmatch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "TeamId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "TeamId" });
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId, cascadeDelete: false)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId, cascadeDelete: false)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "AwayTeamId" });
            DropIndex("dbo.Matches", new[] { "HomeTeamId" });
            DropTable("dbo.Matches");
            CreateIndex("dbo.Matches", "TeamId");
            AddForeignKey("dbo.Matches", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
    }
}
