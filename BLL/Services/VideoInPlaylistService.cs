using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Factories;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Video;
using Domain.Video;
using NLog.LayoutRenderers.Wrappers;

namespace BLL.Services
{
   public class VideoInPlaylistService
    {
        private DAL.Interfaces.IVideoInPlaylistRepository _repo;
        private VideoInPlaylistFactory _factory;
        private VideoFactory _videoFactory;
        private PlaylistFactory _playlistFactory;
        private readonly NLog.ILogger _logger;

        public VideoInPlaylistService()
        {
            this._repo = new VideoInPlaylistRepository(new DataBaseContext(_logger));
            this._factory = new VideoInPlaylistFactory();
            this._videoFactory = new VideoFactory();
        }

       public List<VideoInPlaylistDTO> GetAllVideoInPlaylists()
       {
           return _repo.All.Select(x => _factory.CreateBasicVideoInPlaylistDto(x)).ToList();
       }

        /*
         *get all videos in 1 playlist by playlist id 
         */
       public List<VideoDTO> GetAllVideosInPlaylistByPlaylistId(int playlistId)
       {
           return
               _repo.All.Where(x => x.PlaylistId == playlistId)
                   .Select(x => _videoFactory.CreateBasicVideoDto(x.Video))
                   .ToList();
       }

        /*
         * get all playlists for 1 video by video id
         */
       public List<VideoDTO> GetAllPlaylistsForVideoByVideoId(int videoId)
       {
           return
               _repo.All.Where(x => x.VideoId == videoId)
                   .Select(x => _videoFactory.CreateBasicVideoDto(x.Video))
                   .ToList();
       } 
    }
}
