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
    public class NewsPhotosController : Controller
    {
        private CommonContext db = new CommonContext();

        // GET: NewsPhotos
        public ActionResult Index()
        {
            var newsPhotoes = db.NewsPhotoDetails.Include(n => n.News);
            return View(newsPhotoes.ToList());
        }

        // GET: NewsPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsPhotoDetail newsPhoto = db.NewsPhotoDetails.Find(id);
            if (newsPhoto == null)
            {
                return HttpNotFound();
            }
            return View(newsPhoto);
        }

        // GET: NewsPhotos/Create
        public ActionResult Create()
        {
            ViewBag.NewsID = new SelectList(db.News, "NewsID", "Title");
            return View();
        }

        // POST: NewsPhotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsPhotoID,NewsID,PhotoLocation")] NewsPhotoDetail newsPhoto)
        {
            if (ModelState.IsValid)
            {
                db.NewsPhotoDetails.Add(newsPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NewsID = new SelectList(db.News, "NewsID", "Title", newsPhoto.NewsID);
            return View(newsPhoto);
        }

        // GET: NewsPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsPhotoDetail newsPhoto = db.NewsPhotoDetails.Find(id);
            if (newsPhoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsID = new SelectList(db.News, "NewsID", "Title", newsPhoto.NewsID);
            return View(newsPhoto);
        }

        // POST: NewsPhotos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsPhotoID,NewsID,PhotoLocation")] NewsPhotoDetail newsPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewsID = new SelectList(db.News, "NewsID", "Title", newsPhoto.NewsID);
            return View(newsPhoto);
        }

        // GET: NewsPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsPhotoDetail newsPhoto = db.NewsPhotoDetails.Find(id);
            if (newsPhoto == null)
            {
                return HttpNotFound();
            }
            return View(newsPhoto);
        }

        // POST: NewsPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsPhotoDetail newsPhoto = db.NewsPhotoDetails.Find(id);
            db.NewsPhotoDetails.Remove(newsPhoto);
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
