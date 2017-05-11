namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class League : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SeasonLeauges", newName: "SeasonLeagues");
            DropForeignKey("dbo.Matches", "SeasonLeauge_Id", "dbo.SeasonLeauges");
            DropIndex("dbo.Matches", new[] { "SeasonLeauge_Id" });
            DropColumn("dbo.Matches", "SeasonLeagueId");
            RenameColumn(table: "dbo.Matches", name: "SeasonLeauge_Id", newName: "SeasonLeagueId");
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SeasonLeagues", "LeagueId", c => c.Int(nullable: false));
            AlterColumn("dbo.Matches", "SeasonLeagueId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "SeasonLeagueId");
            CreateIndex("dbo.SeasonLeagues", "LeagueId");
            AddForeignKey("dbo.SeasonLeagues", "LeagueId", "dbo.Leagues", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Matches", "SeasonLeagueId", "dbo.SeasonLeagues", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "SeasonLeagueId", "dbo.SeasonLeagues");
            DropForeignKey("dbo.SeasonLeagues", "LeagueId", "dbo.Leagues");
            DropIndex("dbo.SeasonLeagues", new[] { "LeagueId" });
            DropIndex("dbo.Matches", new[] { "SeasonLeagueId" });
            AlterColumn("dbo.Matches", "SeasonLeagueId", c => c.Int());
            DropColumn("dbo.SeasonLeagues", "LeagueId");
            DropTable("dbo.Leagues");
            RenameColumn(table: "dbo.Matches", name: "SeasonLeagueId", newName: "SeasonLeauge_Id");
            AddColumn("dbo.Matches", "SeasonLeagueId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "SeasonLeauge_Id");
            AddForeignKey("dbo.Matches", "SeasonLeauge_Id", "dbo.SeasonLeauges", "Id");
            RenameTable(name: "dbo.SeasonLeagues", newName: "SeasonLeauges");
        }
    }
}
