using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Factories;
using DAL;
using DAL.Repositories;
using Domain;

namespace BLL.Services
{
   public class VideoService
   {
       private DAL.Interfaces.IVideoRepository _repo;
       private VideoFactory _factory;
       private readonly NLog.ILogger _logger;
        
       public VideoService()
       {
           this._repo = new VideoRepository( new DataBaseContext(_logger));
            this._factory = new VideoFactory();
        }

       public List<VideoDTO> GetAllVideoDtos()
       {
           return this._repo.All.Select(x => _factory.CreateBasicVideoDto(x)).ToList();
       }

       public VideoDTO GetVideoByIntIdDto(int id)
       {
           var query = this._repo.All.Where(x => x.VideoId == id).FirstOrDefault();
           if (query == null) return null;
           return _factory.CreateBasicVideoDto(query);
       }

        public VideoDTO GetVideoByStringIdDto(string videoId)
        {
            var query = this._repo.All.Where(x => x.YoutubeVideoId == videoId).FirstOrDefault();
            if (query == null) return null;
            return _factory.CreateBasicVideoDto(query);
        }
    }
}
