using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;

namespace Web.Controllers.api
{
    [AllowAnonymous]
    public class VideosController : ApiController
    {
        private IVideoRepository _repo;
        private VideoService _service;

        private readonly NLog.ILogger _logger;



        public VideosController()
        {
            this._repo = new VideoRepository(new DataBaseContext(_logger));
            this._service = new VideoService();
        }


        //public string Get()
        //{
        //    return "OK!";
        //}

        // GET: Videos
        [ResponseType(typeof(VideoDTO))]
        public List<VideoDTO> Get()
        {
            return _service.GetAllVideoDtos();
        }
        //private DataBaseContext db = new DataBaseContext();

        // GET: api/Videos/5
        [ResponseType(typeof(VideoDTO))]
        public IHttpActionResult GetVideoByIntId(int id)
        {
            var video = _service.GetVideoByIntIdDto(id);
            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
        }


        // POST: api/Videos
        [ResponseType(typeof(VideoDTO))]
        public IHttpActionResult PostVideo(Domain.Video.Video video)
        {
            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }
            //VideoDTO videoDto = new VideoDTO()
            //{
            //    VideoId =  video.VideoId,
            //    Title = video.Title,
            //    YoutubeVideoId = video.YoutubeVideoId
            //};
            _repo.Add(video);
            _repo.SaveChanges();
            return Ok();
            //May breake, "DefaultApi" replaced with "api/Videos"
            //return CreatedAtRoute("api/Videos", new { id = video.VideoId }, video); //TODO shows post result in redirected page
        }



        // PUT: api/Videos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideoByIntId(int id, Domain.Video.Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != video.VideoId)
            {
                return BadRequest();
            }
            _repo.Add(video);
            try
            {
                _repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_service.GetVideoByIntIdDto(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //// PUT: api/Videos/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutVideo(int id, Video video)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != video.VideoId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(video).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VideoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Videos
        //[ResponseType(typeof(Video))]
        //public IHttpActionResult PostVideo(Video video)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Videos.Add(video);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = video.VideoId }, video);
        //}

        //// DELETE: api/Videos/5
        //[ResponseType(typeof(Video))]
        //public IHttpActionResult DeleteVideo(int id)
        //{
        //    Video video = db.Videos.Find(id);
        //    if (video == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Videos.Remove(video);
        //    db.SaveChanges();

        //    return Ok(video);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool VideoExists(int id)
        //{
        //    return db.Videos.Count(e => e.VideoId == id) > 0;
        //}
    }
}