using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Factories;
using DAL;
using DAL.Repositories;

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

        //public List<> //TODO listi on vaja
    }
}
