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
using System.Text.RegularExpressions;

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
            string uploadDirectoryYears = Path.Combine(Request.PhysicalApplicationPath, @"Photo\Naujienos\" + news.PostDate.Year.ToString());
            string uploadDirectoryMonth = Path.Combine(uploadDirectoryYears, news.PostDate.Month.ToString());
            string uploadDirectory = Path.Combine(uploadDirectoryMonth, news.Title.ToUpper());

            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }


            if (ModelState.IsValid)
            {
                List<NewsPhotoDetail> photoDetails = new List<NewsPhotoDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = i + 1 + Path.GetExtension(file.FileName); //Path.GetFileName(file.FileName);
                        NewsPhotoDetail photoDetail = new NewsPhotoDetail()
                        {
                            FileName = fileName,
                            NewsID = news.NewsID,
                            //Extension = Path.GetExtension(fileName),
                            PhotoLocation = Path.GetExtension(fileName)
                        };
                        photoDetails.Add(photoDetail);


                        ////uploadDirectory = Path.Combine(Request.PhysicalApplicationPath, @"Photo\Naujienos\" + DateTime.ParseExact(IrasoData, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).Year.ToString());
                        ////lblTest.Text += "<br />uploadDirectory=" + uploadDirectory.ToString();
                        ////uploadDirectory = @"C:\Inetpub\wwwroot\Tvarkarasciai";
                        ////jei nera pagrindines direktorijos ji sukuriama
                        //if (!Directory.Exists(uploadDirectory))
                        //{
                        //    Directory.CreateDirectory(uploadDirectory);
                        //}

                        ////jei nera tokiu metu katalogo jis sukuriamas ir i ji keliami tu metu menesiu katalogai o juose tvarkarasciai
                        ////uploadDirectoryYears = Path.Combine(uploadDirectory, DateTime.Now.Month.ToString());
                        //uploadDirectoryYears = Path.Combine(uploadDirectory, DateTime.ParseExact(IrasoData, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).Month.ToString());
                        //lblTest.Text += "<br />uploadDirectoryYears=" + uploadDirectoryYears.ToString();
                        //if (!Directory.Exists(uploadDirectoryYears))
                        //{
                        //    Directory.CreateDirectory(uploadDirectoryYears);
                        //}

                        ////jei nera tokiu metu ir tokio menesio katalogo jis sukuriamas ir i ji saugomi tvarkarasciai
                        //uploadDirectoryMonth = Path.Combine(uploadDirectoryYears, katalogas_is_pavadinimo);
                        //lblTest.Text += "<br />uploadDirectoryMonth=" + uploadDirectoryMonth.ToString();
                        //if (!Directory.Exists(uploadDirectoryMonth))
                        //{
                        //    Directory.CreateDirectory(uploadDirectoryMonth);
                        //}



                        //Regex rgx1 = new Regex("[?:ąĄ]");
                        //Regex rgx2 = new Regex("[?:čČ]");
                        //Regex rgx3 = new Regex("[?:ęĘėĖ]");
                        //Regex rgx4 = new Regex("[?:įĮ]");
                        //Regex rgx5 = new Regex("[?:šŠ]");
                        //Regex rgx6 = new Regex("[?:ųŲūŪ]");
                        //Regex rgx7 = new Regex("[?:žŽ]");
                        //Regex rgx8 = new Regex("[^a-zA-Z0-9 -]");

                        //katalogas_is_pavadinimo = rgx1.Replace(katalogas_is_pavadinimo, "a");
                        //katalogas_is_pavadinimo = rgx2.Replace(katalogas_is_pavadinimo, "c");
                        //katalogas_is_pavadinimo = rgx3.Replace(katalogas_is_pavadinimo, "e");
                        //katalogas_is_pavadinimo = rgx4.Replace(katalogas_is_pavadinimo, "i");
                        //katalogas_is_pavadinimo = rgx5.Replace(katalogas_is_pavadinimo, "s");
                        //katalogas_is_pavadinimo = rgx6.Replace(katalogas_is_pavadinimo, "u");
                        //katalogas_is_pavadinimo = rgx7.Replace(katalogas_is_pavadinimo, "z");
                        //katalogas_is_pavadinimo = rgx8.Replace(katalogas_is_pavadinimo, "");
                        //katalogas_is_pavadinimo = katalogas_is_pavadinimo.Replace(" ", "-");






                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), photoDetail.FileName/* + photoDetail.PhotoLocation*/);
                        file.SaveAs(path);
                    }
                }

                news.NewsPhotoDetails = photoDetails;
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
            var newsPhotos = db.NewsPhotoDetails.Where(ph => ph.NewsID == id).ToList();

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
