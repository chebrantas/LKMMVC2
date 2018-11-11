using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LKMMVC_1.Models;

namespace LKMMVC_1.Controllers
{
    public class AdminBoardController : Controller
    {
        private CommonContext db = new CommonContext();

        // GET: AdminBoard
        public ActionResult Index()
        {
            return View(db.ManagementBiographies.ToList());
        }

        // GET: AdminBoard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagementBiography managementBiography = db.ManagementBiographies.Find(id);
            if (managementBiography == null)
            {
                return HttpNotFound();
            }
            managementBiography.Info = HttpUtility.HtmlDecode(managementBiography.Info);
            return View(managementBiography);
        }


        // GET: AdminBoard/Create
        public ActionResult BiographyCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BiographyCreate([Bind(Include = "ManagementBiographyID,ManagementPersonName,Info")] ManagementBiography managementBiography)
        {
            if (ModelState.IsValid)
            {
                managementBiography.Info = HttpUtility.HtmlEncode(managementBiography.Info);


                db.ManagementBiographies.Add(managementBiography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(managementBiography);
        }


        // GET: AdminBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminBoard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManagementBiographyID,ManagementPersonName,Info")] ManagementBiography managementBiography)
        {
            if (ModelState.IsValid)
            {
                db.ManagementBiographies.Add(managementBiography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(managementBiography);
        }

        // GET: AdminBoard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagementBiography managementBiography = db.ManagementBiographies.Find(id);
            if (managementBiography == null)
            {
                return HttpNotFound();
            }
            return View(managementBiography);
        }

        // POST: AdminBoard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManagementBiographyID,ManagementPersonName,Info")] ManagementBiography managementBiography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(managementBiography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(managementBiography);
        }

        // GET: AdminBoard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagementBiography managementBiography = db.ManagementBiographies.Find(id);
            if (managementBiography == null)
            {
                return HttpNotFound();
            }
            return View(managementBiography);
        }

        // POST: AdminBoard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagementBiography managementBiography = db.ManagementBiographies.Find(id);
            db.ManagementBiographies.Remove(managementBiography);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
