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
    public class BiographiesController : Controller
    {
        private CommonContext db = new CommonContext();

        // GET: Biographies
        public ActionResult Index()
        {
            return View(db.Biographies.Include(e=>e.Educations).ToList());
        }

        // GET: Biographies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biography biography = db.Biographies.Find(id);
            if (biography == null)
            {
                return HttpNotFound();
            }
            return View(biography);
        }

        // GET: Biographies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Biographies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BiographyID,Name,BornDate,BornPlace,Family,Language")] Biography biography)
        {
            if (ModelState.IsValid)
            {
                db.Biographies.Add(biography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biography);
        }

        // GET: Biographies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biography biography = db.Biographies.Find(id);
            if (biography == null)
            {
                return HttpNotFound();
            }
            return View(biography);
        }

        // POST: Biographies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BiographyID,Name,BornDate,BornPlace,Family,Language")] Biography biography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biography);
        }

        // GET: Biographies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biography biography = db.Biographies.Find(id);
            if (biography == null)
            {
                return HttpNotFound();
            }
            return View(biography);
        }

        // POST: Biographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Biography biography = db.Biographies.Find(id);
            db.Biographies.Remove(biography);
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
