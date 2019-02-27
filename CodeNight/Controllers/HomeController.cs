using CodeNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeNight.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        CodeNightEntities db = new CodeNightEntities();
        public ActionResult Anasayfa()
        {
            var model = db.Tbl_Urun.ToList();
            return View(model);
        }
    }
}
