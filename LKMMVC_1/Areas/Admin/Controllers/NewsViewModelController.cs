using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using LKMMVC_1.Models;
using LKMMVC_1.Areas.Admin.ViewModel;

namespace LKMMVC_1.Areas.Admin.Controllers
{
    public class NewsViewModelController : Controller
    {
        private CommonContext db = new CommonContext();
        
        // GET: Admin/NewsViewModel
        public ActionResult Index()
        {
            //var news = db.NewsPhotos.Include(np => np.News).ToList();
            //var news1 = db.News.Find(1);
            //var news2 = db.NewsPhotos.FirstOrDefault(a => a.NewsID == 1);

            //NewsViewModel newsViewModel = new NewsViewModel()
            //{
            //    NewsID = news1.NewsID,
            //    PostDate = news1.PostDate,
            //    Content = news1.Content,
            //    Title = news1.Title,
            //    PhotoLocation = news2.PhotoLocation.ToList(),
            //}; 
            return View(db.News.ToList());
        }

        // GET: Admin/NewsViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NewsViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NewsViewModel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NewsViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/NewsViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NewsViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NewsViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
