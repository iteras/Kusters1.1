namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added2TablesPlaylistAndVideoInPlaylistSODAMNLONGNAME : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoInPlaylist",
                c => new
                    {
                        VideoInPlaylistId = c.Int(nullable: false, identity: true),
                        VideoId = c.Int(nullable: false),
                        PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoInPlaylistId)
                .ForeignKey("dbo.Playlist", t => t.PlaylistId)
                .ForeignKey("dbo.Video", t => t.VideoId)
                .Index(t => t.VideoId)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        PlaylistName = c.String(maxLength: 64),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlaylistId)
                .ForeignKey("dbo.UserInt", t => t.UserId)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.Video", "YoutubeVideoId", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoInPlaylist", "VideoId", "dbo.Video");
            DropForeignKey("dbo.VideoInPlaylist", "PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.Playlist", "UserId", "dbo.UserInt");
            DropIndex("dbo.Playlist", new[] { "UserId" });
            DropIndex("dbo.VideoInPlaylist", new[] { "PlaylistId" });
            DropIndex("dbo.VideoInPlaylist", new[] { "VideoId" });
            AlterColumn("dbo.Video", "YoutubeVideoId", c => c.String(nullable: false));
            DropTable("dbo.Playlist");
            DropTable("dbo.VideoInPlaylist");
        }
    }
}
