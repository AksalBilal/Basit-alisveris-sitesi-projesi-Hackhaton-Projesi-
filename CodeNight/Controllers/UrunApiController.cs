using CodeNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CodeNight.Controllers
{
    public class UrunApiController : ApiController
    {
        // GET: UrunApi

        CodeNightEntities db = new CodeNightEntities();
        public IEnumerable<Tbl_Urun> GetUrunler()
        {
            return db.Tbl_Urun.ToList();
           
        }
        public void PostEkle(Tbl_Urun urun)
        {
            if(ModelState.IsValid)
            {
                db.Tbl_Urun.Add(urun);
            }
        }
    }
}