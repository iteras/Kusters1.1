using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dal;
using Dal.Interfaces;
using Dal.Repositories;
using DAL.Interfaces;
using Domain;
using Web.ViewModels;

namespace Web.Controllers
{
    public class PicturesController : BaseController
    {
        //private KustersDbContext db = new KustersDbContext();
        //private readonly IPictureRepository _pictureRepository = new PictureRepository(new KustersDbContext());
        private readonly IUOW _uow;
        public PicturesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Pictures
        public ActionResult Index()
        {
            
            return View(_uow.Pictures.All);
        }

        // GET: Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = _uow.Pictures.GetById(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Pictures/Create
        public ActionResult Create()
        {
            var vm = new ProductPictureViewModels();
            vm.AllProducts = new SelectList(
                _uow.Products.All.Select(
                    a => new {a.ProductId, a.Title}).ToList(),
                nameof(Product.ProductId),
                nameof(Product.Title));
            return View(vm);
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PictureId,ProductId,Location,Description,Title")] Picture picture)
        {
            if (ModelState.IsValid)
            {

                _uow.Pictures.Add(picture);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(picture);
        }

        // GET: Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = _uow.Pictures.GetById(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PictureId,Location,Description,Title")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                _uow.Pictures.Update(picture);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(picture);
        }

        // GET: Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = _uow.Pictures.GetById(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = _uow.Pictures.GetById(id);
            _uow.Pictures.Delete(picture);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Pictures.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
