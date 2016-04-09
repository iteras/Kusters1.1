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
    public class ContractsController : Controller
    {
        //private KustersDbContext db = new KustersDbContext();
        //private readonly IContractRepository _contractRepository = new ContractRepository(new KustersDbContext());
        private readonly IUOW _uow;

        public ContractsController(IUOW uow)
        {
            _uow = uow;
        }
            
            // GET: Contracts
        public ActionResult Index()
        {
            return View(_uow.Contracts.All);
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = _uow.Contracts.GetById(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractId,Content,Title")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _uow.Contracts.Add(contract);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = _uow.Contracts.GetById();
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractId,Content,Title")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _uow.Contracts.Update(contract);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = _uow.Contracts.GetById(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = _uow.Contracts.GetById(id);
            _uow.Contracts.Delete(contract);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Contracts.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
