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
    public class PersonsInDealController : Controller
    {
        //private KustersDbContext db = new KustersDbContext();
        //private readonly IPersonInDealRepository _personInDealRepository = new PersonInDealRepository(new KustersDbContext());
        private readonly IUOW _uow;
        public PersonsInDealController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: PersonsInDeal
        public ActionResult Index()
        {
            return View(_uow.PersonInDeals.All);
        }

        // GET: PersonsInDeal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInDeal personInDeal = _uow.PersonInDeals.GetById(id);
            if (personInDeal == null)
            {
                return HttpNotFound();
            }
            return View(personInDeal);
        }

        // GET: PersonsInDeal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonsInDeal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonInDealId,Date")] PersonInDeal personInDeal)
        {
            if (ModelState.IsValid)
            {
                _uow.PersonInDeals.Add(personInDeal);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(personInDeal);
        }

        // GET: PersonsInDeal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInDeal personInDeal = _uow.PersonInDeals.GetById(id);
            if (personInDeal == null)
            {
                return HttpNotFound();
            }
            return View(personInDeal);
        }

        // POST: PersonsInDeal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonInDealId,Date")] PersonInDeal personInDeal)
        {
            if (ModelState.IsValid)
            {
                _uow.PersonInDeals.Update(personInDeal);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(personInDeal);
        }

        // GET: PersonsInDeal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInDeal personInDeal = _uow.PersonInDeals.GetById(id);
            if (personInDeal == null)
            {
                return HttpNotFound();
            }
            return View(personInDeal);
        }

        // POST: PersonsInDeal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonInDeal personInDeal = _uow.PersonInDeals.GetById(id);
            _uow.PersonInDeals.Delete(personInDeal);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.PersonInDeals.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
