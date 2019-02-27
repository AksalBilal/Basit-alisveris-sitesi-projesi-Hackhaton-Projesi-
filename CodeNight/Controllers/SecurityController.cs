using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;
using CodeNight.Models;

namespace ProjeOdevi.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        CodeNightEntities db = new CodeNightEntities();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Tbl_Kullanici kullanici)
        {
            var kullaniciDB = db.Tbl_Kullanici.FirstOrDefault(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.Sifre == kullanici.Sifre);
            if (kullaniciDB!=null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciDB.KullaniciAdi,false);
                return RedirectToAction("AnaSayfa","Home");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Security");
        }
    }
}