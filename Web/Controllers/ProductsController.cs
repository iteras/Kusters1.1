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
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        //private KustersDbContext db = new KustersDbContext();
        //private readonly IProductRepository _productRepository = new ProductRepository(new KustersDbContext());
        private readonly IUOW _uow;
        public ProductsController(IUOW uow)
        {
            _uow = uow;
        }


        // GET: Products
        public ActionResult Index()
        {
            var vm = new ProductViewModels();
            Person person = new Person();
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                vm.AllProducts = _uow.Products.All;
            }
            else
            {
                person = _uow.Persons.GetAllForUser(User.Identity.GetUserId<int>()).First();
                vm.AllProducts = _uow.Products.GetAllProductsForPerson(person.PersonId); //gets all Products for this certain person
                List<Deal> allThisPersonDealIds = _uow.Deals.GetAllDealsForPerson(person.PersonId); //gets all Deals for this certain person
                PersonInDeal asd = new PersonInDeal();
                List<int> allBuyerIds = new List<int>();
                vm.AllBuyers = new List<Person>();
                foreach (var item in allThisPersonDealIds)
                {
                        if (item.PersonsInDeal.First().IsSeller != true)
                        {
                            asd = (item.PersonsInDeal.First());
                            vm.AllBuyers.Add(_uow.Persons.GetById(asd.PersonId));
                        } else
                        {
                            asd = (item.PersonsInDeal.OrderByDescending(a => a.PersonInDealId).First());
                            vm.AllBuyers.Add(_uow.Persons.GetById(asd.PersonId));
                    }
                    //TODO: get ALL THIS person's products Buyers IF there is someone to buy it
                }
            }
            /*TODO: section below here is not completed, gets only 1 dealId but should get all
              TODO: gets only 1 buyer, but should get all
             */
             
            //int dealId = _uow.PersonInDeals.GetAllDealIDsForPerson(person.PersonId).First(); //gets all Deal ID's for this person
            //vm.Buyer = _uow.PersonInDeals.GetBuyerInDealByDealId(dealId,person.PersonId); 
            //TODO: display buyer in seller Index View
            return View(vm);
        }

        //GET: Products/ProductDetails/1
        public ActionResult ProductDetails(int? id)
        {
            var vm = new ProductViewModels();
            vm.Product = _uow.Products.GetById(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(vm);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _uow.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var vm = new ProductViewModels();
            //TODO: get only this person for dropdownlist
            vm.AllPersons = new SelectList(_uow.Persons.GetThisPersonByPersonId(User.Identity.GetUserId<int>()).Take(1).Select(a => new { a.PersonId, a.FirstLastName }), nameof(Person.PersonId), nameof(Person.FirstLastName));
            //if (vm.AllPersons.Count() > 1)
            //{
            //    vm.AllPersons = vm.AllPersons.GetEnumerator(vm.Person);
            //}
            //vm.AllPersons = new SelectList(_uow.Persons.All.Select(a => new {a.PersonId,a.FirstLastName}).ToList(), nameof(Person.PersonId), nameof(Person.FirstLastName));
            return View(vm);
        }
        
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Product product)
        {
            if (ModelState.IsValid)
            {
                product.Created = DateTime.Now;
                _uow.Products.Add(product);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            var vm = new ProductViewModels();
            vm.AllPersons = new SelectList(_uow.Persons.All.Select(a => new { a.PersonId, a.FirstLastName }).ToList(), nameof(Person.PersonId), nameof(Person.FirstLastName));

            return View(vm);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _uow.Products.GetById(id);
            Person GetPerson = _uow.Persons.GetById(product.PersonId);
            if (product == null)
            {
                return HttpNotFound();
            }
            var vm = new ProductViewModels();
            vm.AllPersons = new SelectList(_uow.Persons.All.Select(a => new { a.PersonId, a.FirstLastName }).ToList(), nameof(Person.PersonId), nameof(Person.FirstLastName));
            vm.Product = product;
            vm.Person = GetPerson;
            return View(vm);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product product)
        {
            if (ModelState.IsValid)
            {
                _uow.Products.Update(product);
                _uow.Commit();
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _uow.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _uow.Products.GetById(id);
            _uow.Products.Delete(product);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Products.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
