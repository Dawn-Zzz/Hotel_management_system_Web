using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HotelManagement;
using PagedList;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class RoomTypeController : Controller
    {
        private Hotel_ManagementEntities db = new Hotel_ManagementEntities();

        // GET: Admin/RoomType
        public ActionResult Index(int? page)
        {
            int pageSize = 10; // Số lượng kết quả hiển thị trên mỗi trang
            int pageNumber = (page ?? 1); // Số trang hiện tại, mặc định là 1 nếu không có trang được chọn

            var loaiPhongs = db.LoaiPhongs.OrderBy(lp => lp.TenLoaiPhong)
                                           .ToPagedList(pageNumber, pageSize); // Thực hiện phân trang cho dữ liệu

            return View(loaiPhongs);
        }

        // GET: Admin/RoomType/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhong loaiPhong = db.LoaiPhongs.Find(id);
            if (loaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhong);
        }

        // GET: Admin/RoomType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RoomType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiPhong,TenLoaiPhong,GiaLoaiPhong,HinhAnh,SoNguoiToiDa")] LoaiPhong loaiPhong)
        {
            if (ModelState.IsValid)
            {
                db.LoaiPhongs.Add(loaiPhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiPhong);
        }

        // GET: Admin/RoomType/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["Quyen"].ToString() == "1")
            {
                return RedirectToAction("PreventAccess", "Home");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                LoaiPhong loaiPhong = db.LoaiPhongs.Find(id);
                if (loaiPhong == null)
                {
                    return HttpNotFound();
                }
                return View(loaiPhong);
            }
        }

        // POST: Admin/RoomType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiPhong,TenLoaiPhong,GiaLoaiPhong,HinhAnh,SoNguoiToiDa")] LoaiPhong loaiPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiPhong);
        }

        // GET: Admin/RoomType/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhong loaiPhong = db.LoaiPhongs.Find(id);
            if (loaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhong);
        }

        // POST: Admin/RoomType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiPhong loaiPhong = db.LoaiPhongs.Find(id);
            db.LoaiPhongs.Remove(loaiPhong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Route("Search")]
        public async Task<ActionResult> Search(int? page, string tenLP)
        {
            int pageSize = 10; // Số lượng kết quả hiển thị trên mỗi trang
            int pageNumber = (page ?? 1); // Số trang hiện tại, mặc định là 1 nếu không có trang được chọn

            IQueryable<LoaiPhong> query = db.LoaiPhongs;

            if (!string.IsNullOrEmpty(tenLP))
            {
                query = query.Where(lp => lp.TenLoaiPhong.ToLower().Contains(tenLP.ToLower()));
            }

            var ketqua = query.OrderBy(lp => lp.TenLoaiPhong)
                                    .ToPagedList(pageNumber, pageSize); // Thực hiện phân trang cho kết quả tìm kiếm

            return View("Index", ketqua);
        }

    }
}
