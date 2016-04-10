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

namespace Web.Controllers
{
    public class PretensionsController : BaseController
    {
        //private KustersDbContext db = new KustersDbContext();
        //private readonly IPretensionRepository _pretension = new  PretensionRepository(new KustersDbContext());
        private readonly IUOW _uow;
        public PretensionsController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: Pretensions
        public ActionResult Index()
        {
            return View(_uow.Pretensions.All);
        }

        // GET: Pretensions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pretension pretension = _uow.Pretensions.GetById(id);
            if (pretension == null)
            {
                return HttpNotFound();
            }
            return View(pretension);
        }

        // GET: Pretensions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pretensions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PretensionId,Content,Title")] Pretension pretension)
        {
            if (ModelState.IsValid)
            {
                _uow.Pretensions.Add(pretension);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(pretension);
        }

        // GET: Pretensions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pretension pretension = _uow.Pretensions.GetById(id);
            if (pretension == null)
            {
                return HttpNotFound();
            }
            return View(pretension);
        }

        // POST: Pretensions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PretensionId,Content,Title")] Pretension pretension)
        {
            if (ModelState.IsValid)
            {
                _uow.Pretensions.Update(pretension);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(pretension);
        }

        // GET: Pretensions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pretension pretension = _uow.Pretensions.GetById(id);
            if (pretension == null)
            {
                return HttpNotFound();
            }
            return View(pretension);
        }

        // POST: Pretensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pretension pretension = _uow.Pretensions.GetById(id);
            _uow.Pretensions.Delete(pretension);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Pretensions.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
