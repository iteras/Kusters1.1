using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Video
{
    public class VideoInPlaylist
    {
        [Key]
        public int VideoInPlaylistId { get; set; }

        public int VideoId { get; set; }
        public Video Video { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
