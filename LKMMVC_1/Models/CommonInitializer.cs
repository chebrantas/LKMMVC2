using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LKMMVC_1.Models
{
    public class CommonInitializer:DropCreateDatabaseAlways<CommonContext>
    {
        protected override void Seed(CommonContext context)
        {
            context.News.Add(new News
            {
                Content = "Turinys 1",
                Title = "Pavadinimas 1",
                PostDate = DateTime.Now,
                NewsPhotos = new List<NewsPhoto>
                {
                    new NewsPhoto
                    {
                        NewsID=1,
                        PhotoLocation=@"Photo\2018\10\grazios foto",
                    },
                    new NewsPhoto
                    {
                        NewsID=1,
                        PhotoLocation=@"Photo\2018\11\grazios foto1",
                    }
                }
            });
            context.News.Add(new News
            {
                Content = "Turinys 2",
                Title = "Pavadinimas 2",
                PostDate = DateTime.Now,
                NewsPhotos = new List<NewsPhoto>
                {
                    new NewsPhoto
                    {
                        NewsID=1,
                        PhotoLocation=@"Photo\2018\10\grazios foto22",
                    },
                    new NewsPhoto
                    {
                        NewsID=1,
                        PhotoLocation=@"Photo\2018\11\grazios foto22",
                    }
                }
            });



            base.Seed(context);
        }
    }
}