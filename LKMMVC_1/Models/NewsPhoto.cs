using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKMMVC_1.Models
{
    public class NewsPhoto
    {
        public int NewsPhotoID { get; set; }
        public int NewsID { get; set; }
        public News News { get; set; }
        //nuotraukos kelias serveryje kur fiziskai padeta
        public string PhotoLocation { get; set; }

    }
}