using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeNight.Models;

namespace CodeNight.ModelView
{
    public class UrunAlModelView
    {
        public IEnumerable<Tbl_Kategori> Kategoriler { get; set; }
        public IEnumerable<Tbl_Kullanici> kullanicilar { get; set; }
        public Tbl_Urun urun { get; set; }
        //public HttpPostedFileBase resim { get; set; }
    }
}