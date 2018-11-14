using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LKMMVC_1.Models;

namespace LKMMVC_1.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Authorize(Roles = "Administrator", Users = "donatasdaj@gmail.com")]
    public class BiographiesController : Controller
    {
        private CommonContext db = new CommonContext();

        // GET: Admin/Biographies
        public ActionResult Index()
        {
            return View(db.ManagementBiographies.ToList());
        }

        // GET: Admin/Biographies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminBoard/BiographyCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManagementBiographyID,ManagementPersonName,Info")] ManagementBiography managementBiography)
        {
            if (ModelState.IsValid)
            {
                //encodinimas keliant i DB
                managementBiography.Info = HttpUtility.HtmlEncode(managementBiography.Info);

                db.ManagementBiographies.Add(managementBiography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(managementBiography);
        }

        // GET: AdminBoard/BiographyEdit/5
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
            managementBiography.Info = HttpUtility.HtmlDecode(managementBiography.Info);
            return View(managementBiography);
        }

        // POST: AdminBoard/BiographyEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManagementBiographyID,ManagementPersonName,Info")] ManagementBiography managementBiography)
        {
            if (ModelState.IsValid)
            {
                managementBiography.Info = HttpUtility.HtmlEncode(managementBiography.Info);

                db.Entry(managementBiography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(managementBiography);
        }


        // GET: AdminBoard/BiographyDelete/5
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

        // POST: AdminBoard/BiographyDeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult BiographyDeleteConfirmed(int id)
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
