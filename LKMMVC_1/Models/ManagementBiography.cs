using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LKMMVC_1.Models
{
    public class ManagementBiography
    {
        public int ManagementBiographyID { get; set; }
        [Display(Name ="Vadovybės asmuo")]
        public string ManagementPersonName { get; set; }
        [AllowHtml]
        [Display(Name = "Informacija")]
        public string Info { get; set; }
    }
}