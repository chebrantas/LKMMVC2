using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKMMVC_1.Models
{
    public class News
    {
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public List<NewsPhoto> NewsPhotos { get; set; }
    }
}