using Ictshop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.Areas.Admin.Controllers
{
    public class CategorysController : Controller
    {
        private Qlbanhang db = new Qlbanhang();
        // GET: Admin/Categorys
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var cate = db.Categories.OrderBy(x => x.CategoryId);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(cate.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                //Thêm  sản phẩm mới
                db.Categories.Add(category);
                // Lưu lại
                db.SaveChanges();
                // Thành công chuyển đến trang index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            // Hiển thị dropdownlist
            var ed = db.Categories.Find(id);
            // 
            return View(ed);

        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                // Sửa sản phẩm theo mã sản phẩm
                var oldItem = db.Categories.Find(category.CategoryId);
                oldItem.Name = category.Name;
                oldItem.Description = category.Description;               
                // lưu lại
                db.SaveChanges();
                // xong chuyển qua index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var dt = db.Categories.Find(id);
            return View(dt);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dt = db.Categories.Find(id);
                // Xoá
                db.Categories.Remove(dt);
                // Lưu lại
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}