using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;
using Domain.Video;

namespace BLL.DTO
{
   public class PlaylistDTO
    {
        [Key]
        public int PlaylistId { get; set; }
        [MaxLength(64)]
        [MinLength(1)]
        public string PlaylistName { get; set; }
        public List<int> VideoIds { get; set; } //just in case

        //public virtual List<VideoInPlaylist> VideoInPlaylists { get; set; }
    }
}
