using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.Controllers
{
    public class TiviController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult tivilgpartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 10).Take(4).ToList();
            return PartialView(hp);
        }
        public ActionResult tivisonypartial()
        {
            var dell = db.Sanphams.Where(n => n.Mahang == 9).Take(4).ToList();
            return PartialView(dell);
        }
        public ActionResult tivisspartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 20).Take(4).ToList();
            return PartialView(hp);
        }
        public ActionResult tivitclpartial()
        {
            var dell = db.Sanphams.Where(n => n.Mahang == 21).Take(4).ToList();
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