using CodeNight.Models;
using CodeNight.ModelView;
using CodeNight.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CodeNight.Controllers
{
    
    [Authorize]
    public class UrunController : Controller
    {
        CodeNightEntities db = new CodeNightEntities();
        KullaniciRoleProvider k = new KullaniciRoleProvider();
        // GET: UrunEkle
        [HttpGet]
        public ActionResult UrunEkle()
        {
            var model = new UrunAlModelView
            {
                Kategoriler = db.Tbl_Kategori.ToList(),
                kullanicilar = db.Tbl_Kullanici.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult UrunEkle(Tbl_Urun urun,HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Resimler"), pic);
                file.SaveAs(path);
                urun.Resim = pic;
            }
            var KullaniciID = k.KullaniciIdGetir(User.Identity.Name);
            urun.KullaniciID = Convert.ToInt16(KullaniciID[0]);
            urun.SatildiMi = false;
            db.Tbl_Urun.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Anasayfa","Home");
        }
       public ActionResult UrunDetay(int id)
        {
            Tbl_Urun urun = db.Tbl_Urun.FirstOrDefault(x=>x.UrunId==id);
            return View(urun);
        }
        public ActionResult SatinAl(int id)
        {
            Tbl_Urun urun = db.Tbl_Urun.FirstOrDefault(x => x.UrunId == id);
            var KullaniciID = k.KullaniciIdGetir(User.Identity.Name);
            int kID = Convert.ToInt16(KullaniciID[0]);
            var SatinAlanKullanici = db.Tbl_Kullanici.FirstOrDefault(x=>x.KullaniciId==kID);
            Tbl_UrunAl YeniUrunAl = new Tbl_UrunAl();
            YeniUrunAl.KullaniciID = kID;
            YeniUrunAl.UrunID = id;
            db.Tbl_UrunAl.Add(YeniUrunAl);
            urun.SatildiMi = true;
            db.SaveChanges();
            return RedirectToAction("Anasayfa","Home");
        }
        public ActionResult FavorilereEkle(int id)
        {
            Tbl_Urun urun = db.Tbl_Urun.FirstOrDefault(x => x.UrunId == id);
            var KullaniciID = k.KullaniciIdGetir(User.Identity.Name);
            int kID = Convert.ToInt16(KullaniciID[0]);
            var BegenenKullanici = db.Tbl_Kullanici.FirstOrDefault(x => x.KullaniciId == kID);
            Tbl_Favori FavoriyeEkle = new Tbl_Favori();
            FavoriyeEkle.KullaniciID = kID;
            FavoriyeEkle.UrunID = id;
            db.Tbl_Favori.Add(FavoriyeEkle);
            db.SaveChanges();
            return RedirectToAction("Anasayfa", "Home");
        }
        public ActionResult UrunArama(string q)
        {
            var urun = db.Tbl_Urun.Where(x=>x.Adi.Contains(q));
            return View(urun.ToList());
        }
        public ActionResult AldigimUrunler()
        {
            var KullaniciID = k.KullaniciIdGetir(User.Identity.Name);
            int kID = Convert.ToInt16(KullaniciID[0]);
            var alinanurunler = db.Tbl_UrunAl.Where(k => k.KullaniciID == kID).Include(k => k.Tbl_Kullanici).Include(x => x.Tbl_Urun);
            return View(alinanurunler.ToList());

        }
        public ActionResult Favorilerim()
        {
            var KullaniciID = k.KullaniciIdGetir(User.Identity.Name);
            int kID = Convert.ToInt16(KullaniciID[0]);
            var favoriler = db.Tbl_Favori.Where(k => k.KullaniciID == kID).Include(k => k.Tbl_Kullanici).Include(x => x.Tbl_Urun);
            return View(favoriler.ToList());

        }

        public ActionResult EkledigimUrunler()
        {
            var KullaniciID = k.KullaniciIdGetir(User.Identity.Name);
            int kID = Convert.ToInt16(KullaniciID[0]);
            var ekledigimurun = db.Tbl_Urun.Where(k => k.KullaniciID == kID);
            return View(ekledigimurun.ToList());

        }
    }
}