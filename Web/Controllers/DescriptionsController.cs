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
    public class DescriptionsController : Controller
    {
        //private KustersDbContext db = new KustersDbContext();
        //private readonly IDescriptionRepository _descriptionRepository = new DescriptionRepository(new KustersDbContext());
        // GET: Descriptions
        private readonly IUOW _uow;

        public DescriptionsController(IUOW uow)
        {
            _uow = uow;
        }
        public ActionResult Index()
        {
            return View(_uow.Descriptions.All);
        }

        // GET: Descriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = _uow.Descriptions.GetById(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // GET: Descriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Descriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DescriptionId,Content")] Description description)
        {
            if (ModelState.IsValid)
            {
                _uow.Descriptions.Add(description);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(description);
        }

        // GET: Descriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = _uow.Descriptions.GetById();
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // POST: Descriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DescriptionId,Content")] Description description)
        {
            if (ModelState.IsValid)
            {
                _uow.Descriptions.Update(description);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(description);
        }

        // GET: Descriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = _uow.Descriptions.GetById(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // POST: Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Description description = _uow.Descriptions.GetById(id);
            _uow.Descriptions.Delete(description);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Descriptions.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
