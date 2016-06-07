using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain.Video;

namespace BLL.Factories
{
   public class VideoInPlaylistFactory
    {
       public VideoInPlaylistDTO CreateBasicVideoInPlaylistDto(Domain.Video.VideoInPlaylist videoInPlaylist)
       {
           return new VideoInPlaylistDTO()
           {
               VideoInPlaylistId = videoInPlaylist.VideoInPlaylistId,
               PlaylistId = videoInPlaylist.PlaylistId,
               VideoId = videoInPlaylist.VideoInPlaylistId
           };
       }
    }
}
