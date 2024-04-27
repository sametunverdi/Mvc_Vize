using Mvc_Vize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Vize.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities db = new Database1Entities();
        public ActionResult Index(Yonetici log)
        {
            var user = db.Yonetici.FirstOrDefault(x => x.YoneticiAd == log.YoneticiAd && x.YoneticiSoyad == log.YoneticiSoyad);

            if (user != null)
            {
                Session["AdminName"] = user.YoneticiAd;
                return View("Dashboard");
            }

            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}