namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arbiters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        ArbiterId = c.Int(),
                        SeasonLeagueId = c.Int(nullable: false),
                        SeasonLeauge_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Arbiters", t => t.ArbiterId)
                .ForeignKey("dbo.SeasonLeauges", t => t.SeasonLeauge_Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId, cascadeDelete: false)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId, cascadeDelete: false)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => t.ArbiterId)
                .Index(t => t.SeasonLeauge_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoachId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coaches", t => t.CoachId, cascadeDelete: false)
                .Index(t => t.CoachId);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: false)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.SeasonLeauges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        SeasonId = c.Int(nullable: false),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seasons", t => t.SeasonId, cascadeDelete: false)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.SeasonId)
                .Index(t => t.Team_Id);
            
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
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            DropForeignKey("dbo.SeasonLeauges", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.SeasonLeauges", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.Matches", "SeasonLeauge_Id", "dbo.SeasonLeauges");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "CoachId", "dbo.Coaches");
            DropForeignKey("dbo.Matches", "ArbiterId", "dbo.Arbiters");
            DropIndex("dbo.SeasonLeauges", new[] { "Team_Id" });
            DropIndex("dbo.SeasonLeauges", new[] { "SeasonId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "CoachId" });
            DropIndex("dbo.Matches", new[] { "SeasonLeauge_Id" });
            DropIndex("dbo.Matches", new[] { "ArbiterId" });
            DropIndex("dbo.Matches", new[] { "AwayTeamId" });
            DropIndex("dbo.Matches", new[] { "HomeTeamId" });
            DropTable("dbo.Seasons");
            DropTable("dbo.SeasonLeauges");
            DropTable("dbo.Players");
            DropTable("dbo.Coaches");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
            DropTable("dbo.Arbiters");
        }
    }
}
