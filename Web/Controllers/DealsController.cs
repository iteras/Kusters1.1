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

            if (User.Identity.IsAuthenticated && User.IsInRole("Admin")) //admin view sees all persons
            {
                return View(_uow.Deals.All);
            }
            else
            {
                List<Deal> deals = _uow.Deals.All; //all deals
                List<Deal> foundDeals = new List<Deal>(); //returns all this person's deals
                List<int> dealIds = _uow.PersonInDeals.GetAllDealIDsForPerson(User.Identity.GetUserId<int>()).ToList(); //person Deal id's
         
                var vm = new DealViewModels();
                foreach (var item in deals)
                {
                    if (dealIds.Contains(item.DealId) )
                    {
                        foundDeals.Add(item);
                        
                    }
                }
               
                vm.AllDealsForPerson = foundDeals;
                
                return View(vm);
            }
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
        public ActionResult Create(Person person)
        {
            var vm = new DealViewModels();
            vm.PersonProducts = new SelectList(_uow.Products.GetAllProductsForPerson(person.PersonId).Select(a => new { a.ProductId, a.Title }).ToList(), nameof(Product.ProductId), nameof(Product.Title));
            //if (ModelState.IsValid)
            //{
            //    //deal.Product
            //    //_uow.Deals.Add(deal);
            //    //_uow.Commit();
            //    //return RedirectToAction("Index");
            //}
            return View(vm);
        }



        // POST: Deals/Create with person
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DealViewModels vm)
        {
            vm.PersonProducts = new SelectList(_uow.Products.GetAllProductsForPerson(vm.PersonId).Select(a => new { a.ProductId, a.Title }).ToList(), nameof(Product.ProductId), nameof(Product.Title));
            if (ModelState.IsValid)
            {
                PersonInDeal personInDeal1 = new PersonInDeal(); //first or the person who searches for item to purchase
                PersonInDeal personInDeal2 = new PersonInDeal();// seller of the item
                Person person1 = _uow.Persons.GetAllForUser(User.Identity.GetUserId<int>()).Last(); //get last, as the last can be only 1 user
                Person person2 = _uow.Persons.GetById(vm.PersonId);
                personInDeal1.Date = DateTime.Now;
                personInDeal2.Date = DateTime.Now;

                Deal deal = new Deal()
                {
                    From = DateTime.Now,
                    ProductId = vm.ProductId,
                    Product =  _uow.Products.GetById(vm.ProductId),
                    DealDone = false
            };
                
                _uow.Deals.Add(deal);

                personInDeal1.Person = person1; //purchaser
                personInDeal1.PersonId = person1.PersonId;
                personInDeal1.Deal = deal;
                personInDeal1.DealId = deal.DealId;

                personInDeal2.Person = person2; //seller
                personInDeal2.PersonId = person2.PersonId;
                personInDeal2.Deal = deal;
                personInDeal2.DealId = deal.DealId;
                //vm.Person = person;
                _uow.PersonInDeals.Add(personInDeal1);
                _uow.PersonInDeals.Add(personInDeal2);
                _uow.Commit();
                
                
                 //vm.Deal.
                //_uow.Deals.Add(vm.Deal);
                //_uow.Commit();
                //TODO: PersonsInDeal UNCOMPLETED
                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors); //for debug to see validation errors
            return View(vm);
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
            //vm.Person = _uow.Persons.GetPersonByFirstname(vm.PersonFirstName);
            string searchedFirstName = vm.PersonFirstName;
            if (ModelState.IsValid)
            {
                vm.Person = _uow.Persons.GetPersonByFirstname(searchedFirstName);
                if (vm.Person == null)
                {
                    ModelState.AddModelError(vm.PersonFirstName, @Resources.Common.FindCreateDealPersonNotFound);
                    //ModelState.Remove(vm.PersonFirstName);
                    if (!ModelState.IsValid)
                    {
                        return View(vm);
                    }
                }
                //Create(vm.Person);
                return RedirectToAction("Create", vm.Person); //give person to creation
                //return Create(vm.Person);
            }
            
            return View(vm); //result: something broke, direct back to form filling
        }


        // GET: Deals/Edit/5
        public ActionResult Edit(int? id)
        {
            var vm = new DealViewModels();
            vm.Deal = _uow.Deals.GetById(id);
            vm.PersonProducts = new SelectList(_uow.Products.GetAllProductsForPerson(vm.Deal.ProductId).Select(a => new { a.ProductId, a.Title }).ToList(), nameof(Product.ProductId), nameof(Product.Title));
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             
            if (vm.Deal == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Deals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( DealViewModels vm)
        {
            vm.PersonProducts = new SelectList(_uow.Products.GetAllProductsForPerson(vm.PersonId).Select(a => new { a.ProductId, a.Title }).ToList(), nameof(Product.ProductId), nameof(Product.Title));
            if (ModelState.IsValid)
            {
                _uow.Deals.Update(vm.Deal);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(vm.Deal);
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
