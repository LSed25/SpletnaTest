using B2SpletnaTest.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace B2SpletnaTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Testna spletna stran";
            return View();
        }

        public JsonResult GetData()
        {

            var path = Server.MapPath(@"~/json/seznam.json");
            var webClient = new WebClient();
            var json = webClient.DownloadString(path);
            var podatki = JsonConvert.DeserializeObject<Seznam>(json);
            var osebe = podatki.seznam;
            var idk = JsonConvert.SerializeObject(osebe);

            return Json(idk, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Lokalno(string ime, int starost)
        {
            Imena oseba = new Imena(ime, starost);
            var idk = JsonConvert.SerializeObject(oseba);
            return Json(idk, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Streznik(string ime, int starost)
        {
            Imena oseba = new Imena(ime, starost);
            //json file
            var path = Server.MapPath(@"~/json/seznam.json");
            var webClient = new WebClient();
            var json = webClient.DownloadString(path);
            var podatki = JsonConvert.DeserializeObject<Seznam>(json);
            podatki.seznam.Add(oseba);

            var convertedJson = JsonConvert.SerializeObject(podatki, Formatting.Indented);

            System.IO.File.WriteAllText(path, convertedJson);

            return Json(JsonConvert.SerializeObject(podatki.seznam), JsonRequestBehavior.AllowGet);
        }

    }
}