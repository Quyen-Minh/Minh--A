using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.Controllers
{
    public class LaptopController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // GET: Laptop
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult laptophppartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 5).Take(4).ToList();
            return PartialView(hp);
        }
        public ActionResult laptopdellppartial()
        {
            var dell = db.Sanphams.Where(n => n.Mahang == 6).Take(4).ToList();
            return PartialView(dell);
        }
        public ActionResult laptopaspartial()
        {
            var hp = db.Sanphams.Where(n => n.Mahang == 22).Take(4).ToList();
            return PartialView(hp);
        }
        public ActionResult laptopmbpartial()
        {
            var dell = db.Sanphams.Where(n => n.Mahang == 23).Take(4).ToList();
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