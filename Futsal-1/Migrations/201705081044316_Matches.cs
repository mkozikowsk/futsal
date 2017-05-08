namespace Futsal_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Matches : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TestMatches", newName: "Matches");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Matches", newName: "TestMatches");
        }
    }
}
