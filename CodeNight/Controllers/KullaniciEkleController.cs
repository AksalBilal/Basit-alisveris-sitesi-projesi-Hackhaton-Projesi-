using CodeNight.Models;
using CodeNight.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeNight.Controllers
{
    [Authorize]
    public class KullaniciEkleController : Controller
    {
        CodeNightEntities db = new CodeNightEntities();
        // GET: KullaniciEkle
        [HttpGet]
        public ActionResult KullaniciEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciEkle(Tbl_Kullanici kullanici)
        {
            db.Tbl_Kullanici.Add(kullanici);
            db.SaveChanges();
            return RedirectToAction("Login", "Security");
        }
        
    }
}