namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playlistModelUpgraded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Playlist", "YoutubeVideoId", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Playlist", "PlaylistName", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Playlist", "PlaylistName", c => c.String(maxLength: 64));
            DropColumn("dbo.Playlist", "YoutubeVideoId");
        }
    }
}
