using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Video
{
   public class Video
    {
       
        [Key]
        public int VideoId { get; set; }
        [Required]
        [MaxLength(20)]
        public string YoutubeVideoId { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual List<VideoInPlaylist> VideoInPlaylist { get; set; }
        //public virtual List<Playlist> Playlists { get; set; }
    }
}