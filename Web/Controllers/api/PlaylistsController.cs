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
    //[EnableCors(origins: "http://localhost:43467/", headers: "*", methods : "*")]
    public class PlaylistsController : ApiController
    {
        private IPlaylistRepository _repo;
        private PlaylistService _service;

        private readonly NLog.ILogger _logger;



        public PlaylistsController()
        {
            this._repo = new PlaylistRepository(new DataBaseContext(_logger));
            this._service = new PlaylistService();
        }

        [ResponseType(typeof(PlaylistDTO))]
        public List<PlaylistDTO> GetAllPlaylists()
        {
            return _service.GetAllPlaylistDtos();
        }

        // POST: api/Videos
        [ResponseType(typeof(PlaylistDTO))]
        public IHttpActionResult PostVideo(Domain.Video.Playlist playlist)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            _repo.Add(playlist);
            _repo.SaveChanges();
            return Ok();
            //May breake, "DefaultApi" replaced with "api/Videos"
            //return CreatedAtRoute("api/Videos", new { id = video.VideoId }, video); //TODO shows post result in redirected page
        }

        public IHttpActionResult PutPlaylist(int id,Playlist playlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playlist.PlaylistId)
            {
                return BadRequest();
            }

            _repo.Add(playlist);

            try
            {
                _repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repo.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE: api/Playlists/5
        [ResponseType(typeof(Playlist))]
        public IHttpActionResult DeletePlaylist(int id)
        {
            Playlist playlist = _repo.GetById(id);
            if (playlist == null)
            {
                return NotFound();
            }

            _repo.Delete(playlist);
            _repo.SaveChanges();

            return Ok(playlist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }



        //// GET: api/Playlists/5
        //[ResponseType(typeof(Playlist))]
        //public IHttpActionResult GetPlaylist(int id)
        //{
        //    Playlist playlist = db.Playlists.Find(id);
        //    if (playlist == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(playlist);
        //}

        //// PUT: api/Playlists/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPlaylist(int id, Playlist playlist)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != playlist.PlaylistId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(playlist).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlaylistExists(id))
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

        //// POST: api/Playlists
        //[ResponseType(typeof(Playlist))]
        //public IHttpActionResult PostPlaylist(Playlist playlist)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Playlists.Add(playlist);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = playlist.PlaylistId }, playlist);
        //}

        //// DELETE: api/Playlists/5
        //[ResponseType(typeof(Playlist))]
        //public IHttpActionResult DeletePlaylist(int id)
        //{
        //    Playlist playlist = db.Playlists.Find(id);
        //    if (playlist == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Playlists.Remove(playlist);
        //    db.SaveChanges();

        //    return Ok(playlist);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PlaylistExists(int id)
        //{
        //    return db.Playlists.Count(e => e.PlaylistId == id) > 0;
        //}
    }
}