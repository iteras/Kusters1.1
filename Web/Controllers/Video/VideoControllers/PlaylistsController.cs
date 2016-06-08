using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain.Identity;
using Domain.Video;
using Microsoft.AspNet.Identity;
using Web.ViewModels;

namespace Web.Controllers.Video.VideoControllers
{
    public class PlaylistsController : BaseController
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;
        PlaylistsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Playlists
        public ActionResult Index()
        {
            //var playlists = db.Playlists.Include(p => p.User);
            List <Playlist> allPlaylistsForUser = _uow.Playlists.GetAllPlaylistsForUser(User.Identity.GetUserId<int>()).ToList();
            //TODO get all playlists for this person - created and SHOULD work, NOT TESTED


            return View(allPlaylistsForUser);
        }

        // GET: Playlists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = _uow.Playlists.GetById(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // GET: Playlists/Create
        public ActionResult Create()
        {
            var vm = new PlaylistViewModels();
            int loggedInUserId = User.Identity.GetUserId<int>(); //gets logged in user id
            List<UserInt> AllUserInts = _uow.UsersInt.All;

            //List<Playlist> playlists = _uow.Playlists.All.Where(a => a.UserIntId == loggedInUserId).ToList(); // all logged in user playlists
            //vm.UsersPlaylistsSelectlist = new SelectList(playlists.Select(a => new { a.PlaylistId, a.PlaylistName }).ToList(), "PlaylistId", "Playlistname");
            //vm.UsersPlaylistsSelectlist = new SelectList(playlists.Select(a => new {a.User, a.UserIntId,a.PlaylistName}).ToList(), "UserInt", "UserIntId","Playlistname");

            vm.UserIntListSelectlist = new SelectList(AllUserInts.Select(a => new {a.Id, a.Email}).ToList(),"UserIntId", "Email");//TODO NB! Different of previus, no object is passed on anymore
            //TODO Also, not tested
            //ViewBag.UserId = new SelectList(db.UserInts, "Id", "Email"); //Old solution for dropdownbox
            return View(vm);
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _uow.Playlists.Add(playlist);
                _uow.Playlists.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.UserId = new SelectList(db.UserInts, "Id", "Email", playlist.UserId); //TODO viewmodel
            return View(playlist);
        }

        // GET: Playlists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = _uow.Playlists.GetById(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.UserInts, "Id", "Email", playlist.UserId); //TODO viewmodel
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _uow.Playlists.Update(playlist);
                _uow.Playlists.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.UserInts, "Id", "Email", playlist.UserId); //TODO viewmodel
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = _uow.Playlists.GetById(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Playlist playlist = _uow.Playlists.GetById(id);
            _uow.Playlists.Delete(playlist);
            _uow.Playlists.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Playlists.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
