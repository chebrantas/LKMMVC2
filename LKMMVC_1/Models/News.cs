using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LKMMVC_1.Models
{
    public class News
    {
        public int NewsID { get; set; }
        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }
        [Display(Name = "Turinys")]
        public string Content { get; set; }
        [Display(Name = "Data")]
        public DateTime PostDate { get; set; }
        public List<NewsPhoto> NewsPhotos { get; set; }
    }
}