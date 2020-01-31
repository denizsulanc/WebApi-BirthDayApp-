using BirthDayWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthDayWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DavetiyeFormu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DavetiyeFormu(DavetiyeModel model)
        {
            if (ModelState.IsValid)
            {
                VeriTabani.Add(model);
                return View("Thanks", model); //thanks View'ine gönderiyoruz
            }

            return View(model); //davetiye formuna geri gidecek içindeki bilgilerle
        }
        [ChildActionOnly]
        public ActionResult Katilanlar()
        {
            var katilanlari = VeriTabani.Liste.Where(i => i.KatilmaDurumu == true);
            //var değişkenini tanımlamadan veritabanına yapılan sorguyu partialview'in içine yazabilirdik
            return PartialView(katilanlari);
        }
    }
}