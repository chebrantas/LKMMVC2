using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LKMMVC_1.Models;
using LKMMVC_1.Areas.Admin.ViewModel;
using System.IO;

namespace LKMMVC_1.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private CommonContext db = new CommonContext();

        // GET: Admin/News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }


        // GET: Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Content,PostDate,")] News news)
        {
            //---------------------------

            if (ModelState.IsValid)
            {
                List<NewsPhoto> photoDetails = new List<NewsPhoto>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = i+1 + Path.GetExtension(file.FileName); //Path.GetFileName(file.FileName);
                        NewsPhoto photoDetail = new NewsPhoto()
                        {
                            FileName = fileName,
                            //Extension = Path.GetExtension(fileName),
                            PhotoLocation = Path.GetExtension(fileName)
                        };
                        photoDetails.Add(photoDetail);

                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), photoDetail.FileName/* + photoDetail.PhotoLocation*/);
                        file.SaveAs(path);
                    }
                }

                news.NewsPhotos = photoDetails;
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            //------------------------
            //if (ModelState.IsValid)
            //{


            //    var a = Request.Files[0].FileName;
            //    var b = Request.Files[1];
            //    var c = Request.Files[2];


            //    news.PostDate = news.PostDate.Add(DateTime.Now.TimeOfDay);
            //    news.Content = HttpUtility.HtmlEncode(news.Content);

            //    db.News.Add(news);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            var newsPhotos = db.NewsPhotos.Where(ph => ph.NewsID == id).ToList();

            NewsViewModel newsViewModel = new NewsViewModel()
            {
                NewsID = news.NewsID,
                PostDate = news.PostDate,
                Content = news.Content,
                Title = news.Title,
                NewsPhotos = newsPhotos
            };


            return View(newsViewModel);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsID,Title,Content,PostDate")] News news)
        {
            if (ModelState.IsValid)
            {

                news.Content = HttpUtility.HtmlEncode(news.Content);

                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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
