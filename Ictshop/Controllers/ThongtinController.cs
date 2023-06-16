using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.Controllers
{
    public class ThongtinController : Controller
    {
        Qlbanhang db=new Qlbanhang();
        // GET: Thongtin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult spbanchay()
        {
            return View();
        }
        public ActionResult spsapramat()
        {
            return View();
        }
        public ActionResult spmoiramat()
        {
            return View();
        }
        public ActionResult Tinmoinhat()
        {
            var tm = db.Posts.Where(n => n.CategoryId == 3).Take(1).ToList();          
            return PartialView(tm);
        }
        public ActionResult Tinmoikhuyenmai()
        {
            var tm = db.Posts.Where(n => n.CategoryId == 6).Take(1).ToList();
            return PartialView( tm);
        }
        public ActionResult Tinmoicongnghe()
        {
            var tm = db.Posts.Where(n => n.CategoryId == 4).Take(1).ToList();
            return PartialView(tm);
        }
        public ActionResult Tinmoidanhgiasanpham()
        {
            var tm = db.Posts.Where(n => n.CategoryId == 7).Take(1).ToList();
            return PartialView( tm);
        }
        public ActionResult xemchitiet(int Masp = 0)
        {
            var chitiet = db.Posts.SingleOrDefault(n => n.Id == Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
    }
}