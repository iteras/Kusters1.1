using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain.Video
{
   public class Playlist
    {
        [Key]
       public int PlaylistId { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
       public string PlaylistName { get; set; }
       public List<int> VideoIds { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual UserInt User { get; set; }

        public virtual List<VideoInPlaylist> VideoInPlaylists { get; set; }
    }
}
