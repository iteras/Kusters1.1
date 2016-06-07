using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain.Video;

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
        [HttpGet]
        public List<VideoDTO> GetRekt()
        {
            return _service.GetAllVideoDtos();
        }
        //private DataBaseContext db = new DataBaseContext();

        //// GET: api/Videos
        //public IQueryable<Domain.Video.Video> GetVideos()
        //{
        //    return db.Videos;
        //}

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