using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Video;

namespace DAL.Repositories.Video
{
   public class VideoInPlaylistRepository : EFRepository<VideoInPlaylist>, IVideoInPlaylistRepository
    {
       public VideoInPlaylistRepository(IDbContext dbContext) : base(dbContext)
       {
       }
    }
}
