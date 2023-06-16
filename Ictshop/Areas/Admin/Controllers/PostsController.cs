using Ictshop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // GET: Admin/Post
        //public ActionResult Index(int? page)
        //{
        //    if (page == null) page = 1;
        //    var sp = db.Posts.OrderBy(x => x.Id);
        //    int pageSize = 5;
        //    int pageNumber = (page ?? 1);
        //    return View(sp.ToPagedList(pageNumber, pageSize));
        //}
        public ActionResult Index(int? page, string Searchtext)
        {
            var pageSize = 1;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Post> items = db.Posts.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Title.Contains(Searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);

        }
        public ActionResult details(int id)
        {
            var dt = db.Posts.Find(id);
            return View(dt);
        }
        //public ActionResult create()
        //{
        //    ViewBag.CategoryList = new SelectList(db.Categories, "CategoryId", "Name");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult create(Post post)
        //{
        //    try
        //    {
        //        //Thêm sản phẩm mới
        //        db.Posts.Add(post);
        //        // Lưu lại
        //        db.SaveChanges();
        //        // Thành công chuyển đến trang index
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.CategoryList = new SelectList(db.Categories, "CategoryId", "Name");
        //        ViewBag.Error = "Đã có lỗi xảy ra khi lưu vào CSDL: " + ex.Message;
        //        return View();
        //    }
        //}
        public ActionResult create()
        {
            var categories = db.Categories.ToList();
            SelectList categoryList = new SelectList(categories, "CategoryId", "Name");
            ViewBag.CategoryList = categoryList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (post.CategoryId == null)
                    {
                        post.CategoryId = 1; // Set a default category if one is not selected
                    }

                    db.Posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.CategoryList = new SelectList(db.Categories, "CategoryId", "Name");
                return View(post);
            }
            catch (Exception ex)
            {
                ViewBag.CategoryList = new SelectList(db.Categories, "CategoryId", "Name");
                ViewBag.Error = "Error: " + ex.Message;
                return View(post);
            }
        }
        //public ActionResult edit(int id)
        //{
        //    var dt = db.Posts.Find(id);
        //    ViewBag.CategoryList = new SelectList(db.Categories, "CategoryId", "Name", dt.Id);
        //    return View(dt);
        //}
        //[HttpPost]
        //public ActionResult edit(Post post)
        //{
        //    try
        //    {
        //        // Sửa sản phẩm theo mã sản phẩm
        //        var oldItem = db.Posts.Find(post.Id);
        //        oldItem.Title = post.Title;
        //        oldItem.ShortDescription = post.ShortDescription;
        //        oldItem.PostContent = post.PostContent;
        //        oldItem.Anh = post.Anh;
        //        oldItem.Published = post.Published;
        //        oldItem.Posted_on = post.Posted_on;
        //        oldItem.Modified = post.Modified;
        //        oldItem.Url = post.Url;
        //        oldItem.Id = post.Id;
        //        // lưu lại
        //        db.SaveChanges();
        //        // xong chuyển qua index
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult edit(int id)
        {
            var dt = db.Posts.Find(id);
            ViewBag.CategoryList = new SelectList(db.Categories, "CategoryId", "Name", dt.CategoryId);
            return View(dt);
        }
        [HttpPost]
        public ActionResult edit(Post post)
        {
            try
            {
                // Sửa sản phẩm theo mã sản phẩm
                var oldItem = db.Posts.Find(post.Id);
                oldItem.Title = post.Title;
                oldItem.ShortDescription = post.ShortDescription;
                oldItem.PostContent = post.PostContent;
                oldItem.Anh = post.Anh;
                oldItem.Published = post.Published;
                oldItem.Posted_on = post.Posted_on;
                oldItem.Modified = post.Modified;
                oldItem.Url = post.Url;
                oldItem.CategoryId = post.CategoryId;
                // lưu lại
                db.SaveChanges();
                // xong chuyển qua index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.CategoryList = new SelectList(db.Categories, "CategoryId", "Name", post.CategoryId);
                ViewBag.Error = "Đã có lỗi xảy ra khi lưu vào CSDL: " + ex.Message;
                return View();
            }
        }
        public ActionResult delete(int id)
        {
            var dt = db.Posts.Find(id);
            return View(dt);
        }
        [HttpPost]
        public ActionResult delete(int id, FormCollection collection)
        {
            try
            {
                //Lấy được thông tin sản phẩm theo ID(mã sản phẩm)
                var dt = db.Posts.Find(id);
                // Xoá
                db.Posts.Remove(dt);
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