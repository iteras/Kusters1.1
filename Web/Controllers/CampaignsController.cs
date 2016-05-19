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
using DAL;
using DAL.Interfaces;
using Domain;

namespace Web.Controllers
{
    [Authorize]
    public class CampaignsController : BaseController
    {
        //  private KustersDbContext db = new KustersDbContext();

        //private readonly ICampaignRepository _campaignRepository = new CampaignRepository(new DataBaseContext());
        private readonly IUOW _uow;
        public CampaignsController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: Campaigns
        public ActionResult Index()
        {
            return View(_uow.Campaigns.All);
        }

        // GET: Campaigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = _uow.Campaigns.GetById(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // GET: Campaigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampaignId, Description,Percentage,From,Until")] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                _uow.Campaigns.Add(campaign);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(campaign);
        }

        // GET: Campaigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = _uow.Campaigns.GetById(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampaignId,Description,Percentage,From,Until")] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                _uow.Campaigns.Update(campaign);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = _uow.Campaigns.GetById(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campaign campaign = _uow.Campaigns.GetById(id);
            _uow.Campaigns.Delete(campaign);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Campaigns.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
