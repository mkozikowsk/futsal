namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchSeason : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "SeasonLeagueId", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "SeasonLeauge_Id", c => c.Int());
            CreateIndex("dbo.Matches", "SeasonLeauge_Id");
            AddForeignKey("dbo.Matches", "SeasonLeauge_Id", "dbo.SeasonLeauges", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "SeasonLeauge_Id", "dbo.SeasonLeauges");
            DropIndex("dbo.Matches", new[] { "SeasonLeauge_Id" });
            DropColumn("dbo.Matches", "SeasonLeauge_Id");
            DropColumn("dbo.Matches", "SeasonLeagueId");
        }
    }
}
