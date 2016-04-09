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
using Microsoft.AspNet.Identity;
using System.Web.UI.WebControls;

namespace Web.Controllers
{
    public class PersonsController : Controller
    {
     //   private KustersDbContext db = new KustersDbContext();

      // private readonly IPersonRepository _personRepository = new PersonRepository(new KustersDbContext());
        private readonly IUOW _uow;

        public PersonsController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: Persons
        public ActionResult Index()
        {
            return View(_uow.Persons.GetAllForUser(User.Identity.GetUserId<int>()));
        }

        // GET: Persons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _uow.Persons.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,FirstName,SecondName,Sex,Email,Password,TelNr,BankNr,Locked,Money,Invited,Rating")] Person person)
        {
            if (ModelState.IsValid)
            {
                _uow.Persons.Add(person);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _uow.Persons.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,SecondName,Sex,Email,Password,TelNr,BankNr,Locked,Money,Invited,Rating")] Person person)
        {
            if (ModelState.IsValid)
            {
                _uow.Persons.Update(person);
                _uow.Commit();
                //db.Entry(person).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Persons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _uow.Persons.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = _uow.Persons.GetById(id);
            _uow.Persons.Delete(person);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Persons.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
