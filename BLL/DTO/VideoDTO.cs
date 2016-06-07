using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public class VideoDTO
    {
        [Key]
        public int VideoId { get; set; }
        [RequiredAttribute]
       public string YoutubeVideoId { get; set; }
        [RequiredAttribute]
       public string Title { get; set; }
    }
}
