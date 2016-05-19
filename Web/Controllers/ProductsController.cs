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
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                vm.AllProducts = _uow.Products.All;
            }
            else
            {
                //List<Person> person = _uow.Persons.GetAllForUser(User.Identity.GetUserId<int>());


                Person person = _uow.Persons.GetAllForUser(User.Identity.GetUserId<int>()).First();
                vm.AllProducts = _uow.Products.GetAllProductsForPerson(person.PersonId);


            }
            
            //vm.AllPersons = new SelectList(_uow.Persons.All.
            //    Select(a => new {a.PersonId, a.FirstName, a.LastName}).ToList()
            //    ,nameof(Person.PersonId)
            //    ,nameof(Person.FirstName)
            //    ,nameof(Person.LastName));
            //vm.AllProducts = _uow.Products.All.ToList();
            return View(vm);
        }

        //// GET: Products by person
        //public ActionResult Index(Person person)
        //{
        //    var vm = new ProductViewModels();
        //    vm.GetProductByPerson = _uow.Products.All
        //            .Where(a => a.PersonId == person.PersonId)
        //            .ToList();
        //    return View(vm);
        //}

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
            vm.AllPersons = new SelectList(_uow.Persons.All.Select(a => new {a.PersonId,a.FirstLastName}).ToList(), nameof(Person.PersonId), nameof(Person.FirstLastName));
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
