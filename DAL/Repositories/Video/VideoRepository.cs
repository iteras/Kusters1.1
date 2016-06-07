using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Video;

namespace DAL.Repositories
{
   public class VideoRepository : EFRepository<Domain.Video.Video>, IVideoRepository
    {
       public VideoRepository(IDbContext dbContext) : base(dbContext)
       {
       }

       //public List<VideoDTO> getAllVideos()
       //{
       //    return DbSet.Select(x => new VideoFactory(createV))
       //}
    }
}
