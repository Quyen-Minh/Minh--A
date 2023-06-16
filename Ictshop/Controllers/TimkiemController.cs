using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Ictshop.Controllers
{
    public class TimkiemController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        [HttpGet]
        // GET: Timkiem
        public ActionResult search(string SearchString, int? page)
        {
            //TÌM KIẾM
            if(Request.HttpMethod== "GET") {
                page = 1;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var tk = db.Sanphams.Where(n => n.Tensp.Contains(SearchString));
            ViewBag.Tukhoa = SearchString;
            return View(tk.OrderBy(n => n.Tensp).ToPagedList(pageNumber,pageSize));
        }
        [HttpPost]
        // GET: Timkiem
        public ActionResult laysearch(string SearchString)
        {
            //goi ve ham get tìm kiếm         
            return RedirectToAction("search", new {@SearchString=SearchString}) ;
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