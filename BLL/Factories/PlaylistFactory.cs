using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain.Video;
using Resources;

namespace BLL.Factories
{
   public class PlaylistFactory
    {
        public DTO.PlaylistDTO CreateBasicPlaylistDto(Domain.Video.Playlist playlist)
        {
            return new PlaylistDTO()
            {
                PlaylistId = playlist.PlaylistId,
                PlaylistName = playlist.PlaylistName,
                YoutubeVideoId = playlist.YoutubeVideoId
            };
        }
    }
}
