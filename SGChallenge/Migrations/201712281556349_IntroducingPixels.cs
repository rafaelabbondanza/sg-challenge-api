namespace SGChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntroducingPixels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pixels",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Views = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            AddColumn("dbo.ArticleTrackers", "PixelCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticleTrackers", "PixelCode");
            DropTable("dbo.Pixels");
        }
    }
}
