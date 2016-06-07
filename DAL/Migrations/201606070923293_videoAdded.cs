namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class videoAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        VideoId = c.Int(nullable: false, identity: true),
                        YoutubeVideoId = c.String(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VideoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Video");
        }
    }
}
