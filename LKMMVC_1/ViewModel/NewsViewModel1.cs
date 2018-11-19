using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LKMMVC_1.Models;

namespace LKMMVC_1.ViewModel
{
    public class NewsViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        //public string PhotoLocation { get; set; }
        public List<NewsPhoto> NewsPhotos { get; set; }
    }
}