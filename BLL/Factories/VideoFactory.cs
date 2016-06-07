using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Resources;

namespace BLL.Factories
{
   public class VideoFactory
    {
       public DTO.VideoDTO CreateBasicVideoDto(Domain.Video.Video video)
       {
           return new VideoDTO()
           {
               VideoId = video.VideoId,
               YoutubeVideoId = video.YoutubeVideoId,
               Title = video.Title
           };
       }
    }
}
