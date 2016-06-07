using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Factories;
using DAL;
using DAL.Repositories;
using Domain.Video;

namespace BLL.Services
{
    public class PlaylistService
    {
        private DAL.Interfaces.IPlaylistRepository _repo;
        private PlaylistFactory _factory;
        private readonly NLog.ILogger _logger;

        public PlaylistService()
        {
            this._repo = new PlaylistRepository(new DataBaseContext(_logger));
            this._factory = new PlaylistFactory();
        }


        /*
         * Get all playlists
         */
        public List<PlaylistDTO> GetAllPlaylistDtos()
        {
            return _repo.All.Select(x => _factory.CreateBasicPlaylistDto(x)).ToList();
        }

        /*
         * Get all playlists for userId
         * IS NOT PERSON, IS USER - RECOGNISED BY LOGIN INFO
         */
        public List<PlaylistDTO> GetAllPlaylistsForUserByUserIntId(int userIntId)
        {
            return _repo.All.Where(x => x.UserId == userIntId).Select(x => _factory.CreateBasicPlaylistDto(x)).ToList();
        } 
       
    }
}
