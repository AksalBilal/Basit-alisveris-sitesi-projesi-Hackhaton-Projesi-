using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeNight.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        public ActionResult MesajGonder()
        {
            return View();
        }
    }
}