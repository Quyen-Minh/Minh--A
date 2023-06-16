using Ictshop.Areas.Admin.Models;
using Ictshop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Ictshop.Areas.Admin.Controllers
{
    public class OderController : Controller
    {
        // GET: Admin/Oder
        private Qlbanhang db = new Qlbanhang();
        public ActionResult Index(int? page)
        {
            //if (page == null) page = 1;
            //var donhang = db.Chitietdonhangs.OrderBy(x => x.Madon);
            //int pageSize = 10;
            //int pageNumber = (page ?? 1);
            //return View(donhang.ToPagedList(pageNumber, pageSize));
            var danhSachDonHang = db.Donhangs.ToList().ToPagedList(page ?? 1, 10);
            var danhSachChiTietDonHang = db.Chitietdonhangs.ToList().ToPagedList(page ?? 1, 10);

            var viewModel = danhSachDonHang.Select(donhang => new DonhangViewModel
            {
                Donhang = donhang,
                Chitietdonhang = danhSachChiTietDonHang.FirstOrDefault(chitiet => chitiet.Madon == donhang.Madon)
            }).ToPagedList(page ?? 1, 10);

            return View(viewModel);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var donhang = db.Donhangs.FirstOrDefault(d => d.Madon == id);
            var chitietdonhang = db.Chitietdonhangs.FirstOrDefault(c => c.Madon == donhang.Madon);

            if (donhang == null || chitietdonhang == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DonhangViewModel
            {
                Donhang = donhang,
                Chitietdonhang = chitietdonhang
            };

            return View(viewModel);
        }

        public ActionResult Delete(int? Madon)
        {
            if (Madon == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var donhang = db.Donhangs.FirstOrDefault(d => d.Madon == Madon);
            if (donhang == null)
            {
                return HttpNotFound();
            }

            var chitietdonhangs = db.Chitietdonhangs.Where(c => c.Madon == Madon);
            if (chitietdonhangs == null)
            {
                return HttpNotFound();
            }

            db.Chitietdonhangs.RemoveRange(chitietdonhangs);
            db.Donhangs.Remove(donhang);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}