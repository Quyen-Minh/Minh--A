using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.Controllers
{
    public class PhukienController : Controller
    {
        // GET: Phukien
        Qlbanhang db = new Qlbanhang();
        // GET: Laptop
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult phukienpartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 8).Take(4).ToList();
            return PartialView(hp);
        }
        public ActionResult phukienlappartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 15).Take(4).ToList();
            return PartialView(hp);
        }
        public ActionResult phukientvpartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 16).Take(4).ToList();
            return PartialView(hp);
        }
        public ActionResult phukientlpartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 17).Take(4).ToList();
            return PartialView(hp);
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
