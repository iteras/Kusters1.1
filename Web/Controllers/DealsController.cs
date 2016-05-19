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
    public class DealsController : BaseController
    {
        //private KustersDbContext db = new KustersDbContext();
        //private readonly IDealRepository _dealRepository = new DealRepository(new KustersDbContext());
        private readonly IUOW _uow;

        public DealsController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: Deals
        public ActionResult Index()
        {
            return View(_uow.Deals.All);
        }

        // GET: Deals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = _uow.Deals.GetById(id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

        // GET: Deals/Create
        public ActionResult Create()
        {

            return View();
        }



        // GET: Deals/Create with person
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            var vm = new DealViewModels();
            if (ModelState.IsValid)
            {
                vm.Person = person;
                 //vm.Deal.
                //_uow.Deals.Add(vm.Deal);
                //_uow.Commit();
                //TODO: PersonsInDeal UNCOMPLETED
                return View(vm);
            }
            return View();
        }

        // GET: Deals/Create
        public ActionResult FindCreateDeal()
        {
            var vm = new DealViewModels();
            vm.PersonsList = _uow.Persons.All; //TODO : list is given, user inserts name and must select it and it will be posted
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindCreateDeal(DealViewModels vm)
        {
            vm.Person = _uow.Persons.GetPersonByFirstname(vm.PersonFirstName);
            string str = vm.Person.FirstName;
            if (ModelState.IsValid)
            {
                vm.Person = _uow.Persons.GetPersonByFirstname(vm.Person.FirstName);
                Create(vm.Person); //give person to creation
            }
            
            return View(vm); //result: something broke, direct back to form filling
        }

        // POST: Deals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DealId,ProductId,From,Until,DealDone")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                _uow.Deals.Add(deal);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(deal);
        }

        // GET: Deals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = _uow.Deals.GetById(id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

        // POST: Deals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DealId,From,Until,DealDone")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                _uow.Deals.Update(deal);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(deal);
        }

        // GET: Deals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deal deal = _uow.Deals.GetById(id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

        // POST: Deals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deal deal = _uow.Deals.GetById(id);
            _uow.Deals.Delete(deal);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Deals.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
