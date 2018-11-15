using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LKMMVC_1.Models;
using LKMMVC_1.ViewModel;

namespace LKMMVC_1.Areas.Admin.Controllers
{
    public class NewsViewModelsController : Controller
    {
        private CommonContext db = new CommonContext();

        // GET: Admin/NewsViewModels
        public ActionResult Index()
        {
            return View(db.NewsViewModels.ToList());
        }

        // GET: Admin/NewsViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsViewModel newsViewModel = db.NewsViewModels.Find(id);
            if (newsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(newsViewModel);
        }

        // GET: Admin/NewsViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NewsViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Content,PostDate")] NewsViewModel newsViewModel)
        {
            if (ModelState.IsValid)
            {
                db.NewsViewModels.Add(newsViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsViewModel);
        }

        // GET: Admin/NewsViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsViewModel newsViewModel = db.NewsViewModels.Find(id);
            if (newsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(newsViewModel);
        }

        // POST: Admin/NewsViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Content,PostDate")] NewsViewModel newsViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsViewModel);
        }

        // GET: Admin/NewsViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsViewModel newsViewModel = db.NewsViewModels.Find(id);
            if (newsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(newsViewModel);
        }

        // POST: Admin/NewsViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsViewModel newsViewModel = db.NewsViewModels.Find(id);
            db.NewsViewModels.Remove(newsViewModel);
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
