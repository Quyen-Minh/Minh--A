using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.Controllers
{
    public class TulanhController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult tulanhtosibapartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 4).Take(4).ToList();
            return PartialView(hp);
        }
        public ActionResult tulanhpanapartial()
        {
            var dell = db.Sanphams.Where(n => n.Mahang == 14).Take(4).ToList();
            return PartialView(dell);
        }
        public ActionResult tulanhsspartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 18).Take(4).ToList();
            return PartialView(hp);
        }
        public ActionResult tulanhlgpartial()
        {
            var dell = db.Sanphams.Where(n => n.Mahang == 19).Take(4).ToList();
            return PartialView(dell);
        }
        public ActionResult xemchitiet(int Masp = 0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n => n.Masp == Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
    }
}