namespace SGChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PixelFk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArticleTrackers", "PixelCode", c => c.String(maxLength: 128));
            CreateIndex("dbo.ArticleTrackers", "PixelCode");
            AddForeignKey("dbo.ArticleTrackers", "PixelCode", "dbo.Pixels", "Code", true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleTrackers", "PixelCode", "dbo.Pixels");
            DropIndex("dbo.ArticleTrackers", new[] { "PixelCode" });
            AlterColumn("dbo.ArticleTrackers", "PixelCode", c => c.String());
        }
    }
}
