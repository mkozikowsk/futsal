namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchSeason2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SeasonLeauges", "TeamId", "dbo.Teams");
            DropIndex("dbo.SeasonLeauges", new[] { "TeamId" });
            RenameColumn(table: "dbo.SeasonLeauges", name: "TeamId", newName: "Team_Id");
            AlterColumn("dbo.SeasonLeauges", "Team_Id", c => c.Int());
            CreateIndex("dbo.SeasonLeauges", "Team_Id");
            AddForeignKey("dbo.SeasonLeauges", "Team_Id", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeasonLeauges", "Team_Id", "dbo.Teams");
            DropIndex("dbo.SeasonLeauges", new[] { "Team_Id" });
            AlterColumn("dbo.SeasonLeauges", "Team_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SeasonLeauges", name: "Team_Id", newName: "TeamId");
            CreateIndex("dbo.SeasonLeauges", "TeamId");
            AddForeignKey("dbo.SeasonLeauges", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
    }
}
