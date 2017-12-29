namespace SGChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Articles", newName: "ArticleTrackers");
            AddColumn("dbo.Comments", "ArticleTrackerId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "ArticleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "ArticleId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "ArticleTrackerId");
            RenameTable(name: "dbo.ArticleTrackers", newName: "Articles");
        }
    }
}
